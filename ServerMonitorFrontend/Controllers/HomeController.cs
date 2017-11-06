using System;
using System.Collections.Generic;
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
        private readonly IServiceGateway<Server> s = new BLLFacade().GetServerGateway();
        private readonly IServiceGateway<ServerDetail> sd = new BLLFacade().GetServerDetailGateway();

        private readonly IServerDetailAverageGateway serverDetailAverageGateway =
            new BLLFacade().GetServerDetailAverageGateway();
        public ActionResult Index()
        {
            var list = serverDetailAverageGateway.GetAllServerDetailAveragesForPeriod(24, 22);
            var graphdatas = new GraphLogic().GetCpuGraphDatas(list);
            var model = new GraphModel()
            {
                GraphDatas = graphdatas
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
            return PartialView(s.ReadAll());
        }
    }
}