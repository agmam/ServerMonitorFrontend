using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Entities;

namespace ServerMonitorFrontend.Gateways.SecureGateways
{
    public class EventGateway : IServiceGateway<Event>
    {
        public Event Create(Event t)
        {
            var Event = WebApiService.instance.PostAsync<Event>("/api/Events/PostEvent", t, HttpContext.Current.User.Identity.Name).Result;
            return Event;
        }

        public Event Read(int id)
        {
            var Event = WebApiService.instance.GetAsync<Event>("/api/Events/GetEvent/" + id, HttpContext.Current.User.Identity.Name).Result;
            return Event;
        }

        public List<Event> ReadAll()
        {
            var Events = WebApiService.instance.GetAsync<List<Event>>("/api/Events/GetEvents", HttpContext.Current.User.Identity.Name).Result;
            return Events;
        }

        public bool Delete(Event t)
        {
            var Event = WebApiService.instance.DeleteAsync<Event>("/api/Events/DeleteEvent/" + t.Id, HttpContext.Current.User.Identity.Name).Result;
            return Event;
        }

        public bool Update(Event t)
        {
            var Event = WebApiService.instance.PutAsync<Event>("/api/Events/PutEvent/" + t.Id, t, HttpContext.Current.User.Identity.Name).Result;
            return Event;
        }

        public List<Event> ReadAllFromServer(int id)
        {
            var Event = WebApiService.instance.GetAsync<List<Event>>("/api/Events/GetEventsFromServer/" + id, HttpContext.Current.User.Identity.Name).Result;
            return Event;
        }
    }
}