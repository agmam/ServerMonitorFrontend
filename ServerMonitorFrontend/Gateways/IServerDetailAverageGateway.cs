using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace ServerMonitorFrontend.Gateways
{
   public interface IServerDetailAverageGateway : IServiceGateway<ServerDetailAverage>
    {
        List<ServerDetailAverage> GetAllServerDetailAveragesForPeriod(int period, int serverid);
        List<ServerDetailAverage> GetServerDetailAverageByRange(DateTime from, DateTime to, int serverId);
    }
}
