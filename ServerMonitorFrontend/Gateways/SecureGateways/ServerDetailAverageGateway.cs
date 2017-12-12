using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Entities;

namespace ServerMonitorFrontend.Gateways.SecureGateways
{
    public class ServerDetailAverageGateway : IServerDetailAverageGateway
    {
        public ServerDetailAverage Create(ServerDetailAverage t)
        {
            var ServerDetailAverage = WebApiService.instance.PostAsync<ServerDetailAverage>("/api/ServerDetailAverages/PostServerDetailAverage", t, HttpContext.Current.User.Identity.Name).Result;
            return ServerDetailAverage;
        }

        public ServerDetailAverage Read(int id)
        {
            var ServerDetailAverage = WebApiService.instance.GetAsync<ServerDetailAverage>("/api/ServerDetailAverages/GetServerDetailAverage/" + id, HttpContext.Current.User.Identity.Name).Result;
            return ServerDetailAverage;
        }

        public List<ServerDetailAverage> ReadAll()
        {
            var ServerDetailAverages = WebApiService.instance.GetAsync<List<ServerDetailAverage>>("/api/ServerDetailAverages/GetServerDetailAverages", HttpContext.Current.User.Identity.Name).Result;
            return ServerDetailAverages;
        }

        public bool Delete(ServerDetailAverage t)
        {
            var ServerDetailAverage = WebApiService.instance.DeleteAsync<ServerDetailAverage>("/api/ServerDetailAverages/DeleteServerDetailAverage/" + t.Id, HttpContext.Current.User.Identity.Name).Result;
            return ServerDetailAverage;
        }

        public bool Update(ServerDetailAverage t)
        {
            var ServerDetailAverage = WebApiService.instance.PutAsync<ServerDetailAverage>("/api/ServerDetailAverages/PutServerDetailAverage/" + t.Id, t, HttpContext.Current.User.Identity.Name).Result;
            return ServerDetailAverage;
        }

        public List<ServerDetailAverage> ReadAllFromServer(int id)
        {
            var ServerDetailAverage = WebApiService.instance.GetAsync<List<ServerDetailAverage>>("/api/ServerDetailAverages/ReadAllFromServer/" + id, HttpContext.Current.User.Identity.Name).Result;
            return ServerDetailAverage;
        }

        public List<ServerDetailAverage> GetAllServerDetailAveragesForPeriod(int period, int serverid)
        {
            var ServerDetailAverages = WebApiService.instance.GetAsync<List<ServerDetailAverage>>("/api/ServerDetailAverages/GetAllServerDetailAveragesForPeriod?period=" +period+"&serverId="+ serverid, HttpContext.Current.User.Identity.Name).Result;
            return ServerDetailAverages;
        }

        public List<ServerDetailAverage> GetServerDetailAverageByRange(DateTime from, DateTime to, int serverId)
        {
            var ServerDetailAverages = WebApiService.instance.GetAsync<List<ServerDetailAverage>>("/api/ServerDetailAverages/GetServerDetailAverageByRange?from=" + from + "&to="+ to +"&serverId=" + serverId, HttpContext.Current.User.Identity.Name).Result;
            return ServerDetailAverages;
        }
    }
}