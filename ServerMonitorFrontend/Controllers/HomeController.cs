using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Entities;
using ServerMonitorFrontend.Gateways;

namespace ServerMonitorFrontend.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IServiceGateway<Server> s = new BLLFacade().GetServerGatewayUnSecure();
        public ActionResult Index()
        {
            return View(s.ReadAll());
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
    }
}