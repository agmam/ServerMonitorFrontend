using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServerMonitorFrontend.Gateways;

namespace ServerMonitorFrontend.Controllers
{
    public class ServerController : Controller
    {
        private readonly IServerGateway serverGateway =
           new BLLFacade().GetServerGateway();

        [Authorize]
        // GET: Server
        public ActionResult Index()
        {
            var model = serverGateway.ReadAll();
            return View(model);
        }

        [Authorize]
        public ActionResult DeleteServer(int id)
        {
            var s = serverGateway.Read(id);
            if (s != null) { 
                serverGateway.Delete(s);
            }
           return RedirectToAction("Index");
        }
    }
}