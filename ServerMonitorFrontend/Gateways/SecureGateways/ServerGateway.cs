using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Entities;

namespace ServerMonitorFrontend.Gateways.SecureGateways
{
    public class ServerGateway : IServerGateway
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Server Create(Server t)
        {
            var Server = WebApiService.instance.PostAsync<Server>("/api/Servers/PostServer", t, HttpContext.Current.User.Identity.Name).Result;
            return Server;
        }

        public Server Read(int id)
        {
            var Server = WebApiService.instance.GetAsync<Server>("/api/Servers/GetServer/" + id, HttpContext.Current.User.Identity.Name).Result;
            return Server;
        }

        public List<Server> ReadAll()
        {
            var Servers = WebApiService.instance.GetAsync<List<Server>>("/api/Servers/GetServers", HttpContext.Current.User.Identity.Name).Result;
            return Servers;
        }

        public bool Delete(Server t)
        {
            var Server = WebApiService.instance.DeleteAsync<Server>("/api/Servers/DeleteServer/" + t.Id, HttpContext.Current.User.Identity.Name).Result;
            return Server;
        }

        public bool Update(Server t)
        {
            var Server = WebApiService.instance.PutAsync<Server>("/api/Servers/PutServer/" + t.Id, t, HttpContext.Current.User.Identity.Name).Result;
            return Server;
        }

        public List<Server> ReadAllFromServer(int id)
        {
            var Server = WebApiService.instance.GetAsync<List<Server>>("/api/Servers/ReadAllFromServer/" + id, HttpContext.Current.User.Identity.Name).Result;
            return Server;
        }

        public Server GetDefaultServer()
        {
            //var Server = WebApiService.instance.GetAsync<Server>("/api/Servers/GetDefaultServer", HttpContext.Current.User.Identity.Name).Result; //TODO
            return Read(1);
        }
    }
}