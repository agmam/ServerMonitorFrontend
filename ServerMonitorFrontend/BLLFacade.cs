using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Entities;
using ServerMonitorFrontend.Gateways;
using ServerMonitorFrontend.Gateways.SecureGateways;

namespace ServerMonitorFrontend
{
    public class BLLFacade
    {
        public IServiceGateway<EmailRecipient> GetEmailRecipientGateway()
        {
            return new EmailRecipientGateway();
        }
        public IServiceGateway<Event> GetEventGateway()
        {
            return new EventGateway();
        }
        public IServiceGateway<EventType> GetEventTypeGateway()
        {
            return new EventTypeGateway();
        }
        public IServiceGateway<Server> GetServerGateway()
        {
            return new ServerGateway();
        }
        public IServiceGateway<ServerDetail> GetServerDetailGateway()
        {
            return new ServerDetailGateway();
        }
        public IServiceGateway<ServerDetailAverage> GetServerDetailAverageGateway()
        {
            return new ServerDetailAverageGateway();
        }
    }
}