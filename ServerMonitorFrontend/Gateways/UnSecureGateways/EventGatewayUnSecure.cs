using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Entities.Entities;

namespace ServerMonitorFrontend.Gateways
{
    public class EventGatewayUnSecure : AServiceGateway<Event>
    {
        protected override Event CreatePost(Event t, HttpClient client)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("api/Events/PostEvent", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Event>().Result;
            }
            return null;
        }

        protected override Event ReadOne(int id, HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/Events/GetEvent/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Event>().Result;
            }
            return null;
        }

        protected override List<Event> ReadAllRead(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/Events/GetEvents").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<Event>>().Result;
            }
            return new List<Event>();
        }

        protected override bool DeleteDel(Event t, HttpClient client)
        {
            var response = client.DeleteAsync("/api/Events/DeleteEvent/" + t.Id).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        protected override bool UpdatePut(Event t, HttpClient client)
        {
            var response = client.PutAsJsonAsync("api/Events/PutEvent/" + t.Id, t).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        protected override List<Event> ReadAllFromServerRead(int id, HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/Events/ReadAllFromServer/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<Event>>().Result;
            }
            return null;
        }
    }
}