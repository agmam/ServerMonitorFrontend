using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Entities;
using ServerMonitorFrontend.Gateways;
using ServerMonitorFrontend.Logic;
using ServerMonitorFrontend.Models;

namespace ServerMonitorFrontend.Controllers
{

    public class HomeController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IServiceGateway<ServerDetail> sd = new BLLFacade().GetServerDetailGateway();

        private readonly IServerDetailAverageGateway serverDetailAverageGateway =
            new BLLFacade().GetServerDetailAverageGateway();

        private readonly IServerGateway serverGateway =
            new BLLFacade().GetServerGateway();
        private readonly IServiceGateway<Event> eventGateway =
            new BLLFacade().GetEventGateway();
        public ActionResult Index(int id = 1)
        {
            var model = GenerateViewModel(id);
            return View(model);
        }

        private HomeIndexViewModel GenerateViewModel(int id)
        {
            var serverLogic = new ServerLogic();
            var serverModel = serverLogic.getServerModel(id);

            List<Server> servers = serverGateway.ReadAll();
            var list = serverDetailAverageGateway.GetAllServerDetailAveragesForPeriod(24, serverModel.Server.Id);


            var graphLogic = new GraphLogic();
            var graphdatas = graphLogic.GetCpuGraphDatas(list, serverModel.Server.Id);
            var netGraphDatas = graphLogic.GetNetworkGraphDatas(list, serverModel.Server.Id);
            var tempGraphData = graphLogic.GetTemperatureGraphDatas(list, serverModel.Server.Id);
            var events = eventGateway.ReadAllFromServer(serverModel.Server.Id);

            var model = new HomeIndexViewModel()
            {
                GraphDatasCpu = graphdatas,
                GraphDatasNetwork = netGraphDatas,
                GraphDatasTemperature = tempGraphData,
                Avarages = list,
                ServerList = servers,
                ServerModel = serverModel,
                Events = events
                
            };
            return model;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var isauth = User.Identity.IsAuthenticated;
            return View();
        }

        public ActionResult Contact()
        {

            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        [Route("home/GetServerModel/{serverId}")]
        public ActionResult GetServerModel(int serverId)
        {
            return Json(GenerateViewModel(serverId), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("home/GetEventPartialView/{serverId}")]
        public ActionResult GetEventPartialView(int serverId)
        {
            List<Event> events = eventGateway.ReadAllFromServer(serverId);
            return PartialView("~/Views/Home/_EventDetail.cshtml", events) ;
        }
        



    }
}