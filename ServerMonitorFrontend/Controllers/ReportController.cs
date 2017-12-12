using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServerMonitorFrontend.Logic;
using ServerMonitorFrontend.Models;

namespace ServerMonitorFrontend.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            int serverId = 2;
            ReportLogic rl = new ReportLogic();
            var model = rl.GenerateViewModel(DateTime.Now.AddDays(-30), DateTime.Now, serverId);
            return View(model);
        }

        public ActionResult GenerateReport(DateTime from, DateTime to)
        {
            int serverId = 5;
            ReportLogic rl = new ReportLogic();
            var model = rl.GenerateViewModel(from, to, serverId);
            return PartialView("~/Views/Report/_Report.cshtml", model);
        }
    }
}