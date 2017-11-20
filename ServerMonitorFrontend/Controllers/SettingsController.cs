using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServerMonitorFrontend.Models;

namespace ServerMonitorFrontend.Controllers
{
    public class SettingsController : Controller
    {
        [HttpGet]
        public ActionResult GetSettingsDialog()
        {
            SettingsModel settingsModel = new SettingsModel();

            return PartialView("~/Views/Dialog/_SettingsDialog.cshtml", settingsModel);
        }

        [HttpPost]
        public ActionResult UpdateSetting(SettingsModel model)
        {
            return null;
        }
    }
}