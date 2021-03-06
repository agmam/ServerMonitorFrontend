﻿using System;
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
        [Authorize]
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
        [Authorize]
        public ActionResult GetEmailSettingView()
        {
            var model = new SettingsModel
            {
                EmailRecipents = emailRecipientGateway.ReadAll()
            };
            return PartialView("~/Views/Dialog/_SettingsEmail.cshtml", model);
        }
        [Authorize]
        public void EditEmail(int id, string email)
        {
            var recipent = new EmailRecipient {Id = id, Email = email};
            emailRecipientGateway.Update(recipent);
            
        }
        [Authorize]
        public string DeleteEmail(int id)
        {
            var email = emailRecipientGateway.Read(id);
            if (email != null)
            {
                if (emailRecipientGateway.Delete(email))
                {
                    return email.Email;
                }
            }
            return "";
        }

    }
}