using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Entities;

namespace ServerMonitorFrontend.Gateways.SecureGateways
{
    public class EmailRecipientGateway : IServiceGateway<EmailRecipient>
    {
        public EmailRecipient Create(EmailRecipient t)
        {
            var EmailRecipient = WebApiService.instance.PostAsync<EmailRecipient>("/api/EmailRecipients/PostEmailRecipient", t, HttpContext.Current.User.Identity.Name).Result;
            return EmailRecipient;
        }

        public EmailRecipient Read(int id)
        {
            var EmailRecipient = WebApiService.instance.GetAsync<EmailRecipient>("/api/EmailRecipients/GetEmailRecipient/" + id, HttpContext.Current.User.Identity.Name).Result;
            return EmailRecipient;
        }

        public List<EmailRecipient> ReadAll()
        {
            var EmailRecipients = WebApiService.instance.GetAsync<List<EmailRecipient>>("/api/EmailRecipients/GetEmailRecipients", HttpContext.Current.User.Identity.Name).Result;
            return EmailRecipients;
        }

        public bool Delete(EmailRecipient t)
        {
            var EmailRecipient = WebApiService.instance.DeleteAsync<EmailRecipient>("/api/EmailRecipients/DeleteEmailRecipient/" + t.Id, HttpContext.Current.User.Identity.Name).Result;
            return EmailRecipient;
        }

        public bool Update(EmailRecipient t)
        {
            var EmailRecipient = WebApiService.instance.PutAsync<EmailRecipient>("/api/EmailRecipients/PutEmailRecipient/" + t.Id, t, HttpContext.Current.User.Identity.Name).Result;
            return EmailRecipient;
        }

        public List<EmailRecipient> ReadAllFromServer(int id)
        {
            var EmailRecipient = WebApiService.instance.GetAsync<List<EmailRecipient>>("/api/EmailRecipients/ReadAllFromServer/" + id, HttpContext.Current.User.Identity.Name).Result;
            return EmailRecipient;
        }
    }
}