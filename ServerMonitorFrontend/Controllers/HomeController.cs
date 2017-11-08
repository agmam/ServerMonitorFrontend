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
        private readonly IServiceGateway<ServerDetail> sd = new BLLFacade().GetServerDetailGateway();

        private readonly IServerDetailAverageGateway serverDetailAverageGateway =
            new BLLFacade().GetServerDetailAverageGateway();

        private readonly IServerGateway serverGateway =
            new BLLFacade().GetServerGateway();

        public ActionResult Index()
        {
            Server server = serverGateway.GetDefaultServer();
            List<Server> servers = serverGateway.ReadAll();
            var list = serverDetailAverageGateway.GetAllServerDetailAveragesForPeriod(24, server.Id);
            
            var graphLogic = new GraphLogic();
            var graphdatas = graphLogic.GetCpuGraphDatas(list, server.Id);
            var netGraphDatas = graphLogic.GetNetworkGraphDatas(list, server.Id);
           
            var model = new HomeIndexViewModel()
            {
                GraphDatasCpu = graphdatas,
                GraphDatasNetwork = netGraphDatas,
                Avarages = list,
                Server = server,
                ServerList = servers
            };
            return View(model);
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

        public ActionResult RenderPartialView()
        {
            return PartialView(serverGateway.ReadAll());
        }
    }
}