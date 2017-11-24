using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Entities;
using ServerMonitorFrontend.Gateways;
using ServerMonitorFrontend.Gateways.SecureGateways;
using ServerMonitorFrontend.Models;

namespace ServerMonitorFrontend.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IServiceGateway<EmailRecipient> emailRecipientGateway =
            new BLLFacade().GetEmailRecipientGateway();
        private readonly IServiceGateway<EventType> eventTypeGateway =
            new BLLFacade().GetEventTypeGateway();
        [HttpGet]
        public ActionResult GetSettingsDialog()
        {
            SettingsModel settingsModel = new SettingsModel()
            {
                EmailRecipents = emailRecipientGateway.ReadAll(),
                EventTypes = eventTypeGateway.ReadAll()
            };

            return PartialView("~/Views/Dialog/_SettingsDialog.cshtml", settingsModel);
        }

        [HttpPost]
        public ActionResult UpdateSetting(SettingsModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.EventTypes != null)
                {
                    foreach (var eventType in model.EventTypes)
                    {
                        eventTypeGateway.Update(eventType);
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}