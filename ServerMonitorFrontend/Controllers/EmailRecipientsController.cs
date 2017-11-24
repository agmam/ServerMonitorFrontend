using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Entities;
using ServerMonitorFrontend.Gateways;
using ServerMonitorFrontend.Models;

namespace ServerMonitorFrontend.Controllers
{
    public class EmailRecipientsController : Controller
    {
        private readonly IServiceGateway<EmailRecipient> emailRecipientGateway =
            new BLLFacade().GetEmailRecipientGateway();
        [HttpPost]
        public void AddEmailRecipent(string Email)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    emailRecipientGateway.Create(new EmailRecipient
                    {
                        Email = Email
                    });
                }
            }
        }

        public ActionResult GetEmailSettingView()
        {
            var model = new SettingsModel
            {
                EmailRecipents = emailRecipientGateway.ReadAll()
            };
            return PartialView("~/Views/Dialog/_SettingsEmail.cshtml", model);
        }

    }
}