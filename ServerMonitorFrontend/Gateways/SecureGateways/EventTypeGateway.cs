using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Entities;

namespace ServerMonitorFrontend.Gateways.SecureGateways
{
    public class EventTypeGateway : IServiceGateway<EventType>
    {
        public EventType Create(EventType t)
        {
            var EventType = WebApiService.instance.PostAsync<EventType>("/api/EventTypes/PostEventType", t, HttpContext.Current.User.Identity.Name).Result;
            return EventType;
        }

        public EventType Read(int id)
        {
            var EventType = WebApiService.instance.GetAsync<EventType>("/api/EventTypes/GetEventType/" + id, HttpContext.Current.User.Identity.Name).Result;
            return EventType;
        }

        public List<EventType> ReadAll()
        {
            var EventTypes = WebApiService.instance.GetAsync<List<EventType>>("/api/EventTypes/GetEventTypes", HttpContext.Current.User.Identity.Name).Result;
            return EventTypes;
        }

        public bool Delete(EventType t)
        {
            var EventType = WebApiService.instance.DeleteAsync<EventType>("/api/EventTypes/DeleteEventType/" + t.Id, HttpContext.Current.User.Identity.Name).Result;
            return EventType;
        }

        public bool Update(EventType t)
        {
            var EventType = WebApiService.instance.PutAsync<EventType>("/api/EventTypes/PutEventType/" + t.Id, t, HttpContext.Current.User.Identity.Name).Result;
            return EventType;
        }

        public List<EventType> ReadAllFromServer(int id)
        {
            var EventType = WebApiService.instance.GetAsync<List<EventType>>("/api/EventTypes/ReadAllFromServer/" + id, HttpContext.Current.User.Identity.Name).Result;
            return EventType;
        }
    }
}