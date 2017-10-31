using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Entities.Entities;

namespace ServerMonitorFrontend.Gateways
{
    public class EmailrecipientGatewayUnSecure : AServiceGateway<EmailRecipient>
    {
        protected override EmailRecipient CreatePost(EmailRecipient t, HttpClient client)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("api/EmailRecipients/PostEmailRecipient", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<EmailRecipient>().Result;
            }
            return null;
        }

        protected override EmailRecipient ReadOne(int id, HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/EmailRecipients/GetEmailRecipient/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<EmailRecipient>().Result;
            }
            return null;
        }

        protected override List<EmailRecipient> ReadAllRead(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/EmailRecipients/GetEmailRecipients").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<EmailRecipient>>().Result;
            }
            return new List<EmailRecipient>();
        }

        protected override bool DeleteDel(EmailRecipient t, HttpClient client)
        {
            var response = client.DeleteAsync("/api/EmailRecipients/DeleteEmailRecipient/" + t.Id).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        protected override bool UpdatePut(EmailRecipient t, HttpClient client)
        {
            var response = client.PutAsJsonAsync("api/EmailRecipients/PutEmailRecipient/" + t.Id, t).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        protected override List<EmailRecipient> ReadAllFromServerRead(int id, HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/EmailRecipients/ReadAllFromServer/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<EmailRecipient>>().Result;
            }
            return null;
        }
    }
}
