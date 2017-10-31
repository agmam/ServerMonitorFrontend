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
        public IServiceGateway<EmailRecipient> GetEmailRecipientGatewayUnSecure()
        {
            return new EmailRecipientGateway();
        }
        public IServiceGateway<Event> GetEventGatewayUnSecure()
        {
            return new EventGateway();
        }
        public IServiceGateway<EventType> GetEventTypeGatewayUnSecure()
        {
            return new EventTypeGateway();
        }
        public IServiceGateway<Server> GetServerGatewayUnSecure()
        {
            return new ServerGateway();
        }
        public IServiceGateway<ServerDetail> GetServerDetailGatewayUnSecure()
        {
            return new ServerDetailGateway();
        }
        public IServiceGateway<ServerDetailAverage> GetServerDetailAverageGatewayUnSecure()
        {
            return new ServerDetailAverageGateway();
        }
    }
}