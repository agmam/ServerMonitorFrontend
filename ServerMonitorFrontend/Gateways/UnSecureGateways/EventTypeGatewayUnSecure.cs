using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Entities.Entities;

namespace ServerMonitorFrontend.Gateways
{
    public class EventTypeGatewayUnSecure : AServiceGateway<EventType>
    {
        protected override EventType CreatePost(EventType t, HttpClient client)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("api/EventTypes/PostEventType", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<EventType>().Result;
            }
            return null;
        }

        protected override EventType ReadOne(int id, HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/EventTypes/GetEventType/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<EventType>().Result;
            }
            return null;
        }

        protected override List<EventType> ReadAllRead(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/EventTypes/GetEventTypes").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<EventType>>().Result;
            }
            return new List<EventType>();
        }

        protected override bool DeleteDel(EventType t, HttpClient client)
        {
            var response = client.DeleteAsync("/api/EventTypes/DeleteEventType/" + t.Id).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        protected override bool UpdatePut(EventType t, HttpClient client)
        {
            var response = client.PutAsJsonAsync("api/EventTypes/PutEventType/" + t.Id, t).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        protected override List<EventType> ReadAllFromServerRead(int id, HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/EventTypes/ReadAllFromServer/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<EventType>>().Result;
            }
            return null;
        }
    }
}