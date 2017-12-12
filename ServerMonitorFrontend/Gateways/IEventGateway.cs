using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Entities;

namespace ServerMonitorFrontend.Gateways
{
    public interface IEventGateway : IServiceGateway<Event>
    {
        List<Event> GetAllEventsByRange(DateTime from, DateTime to, int serverId);
    }
}