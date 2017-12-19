using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Entities;

namespace ServerMonitorFrontend.Gateways.SecureGateways
{
    public class ServerDetailGateway : IServiceGateway<ServerDetail>
    {

        public ServerDetail Create(ServerDetail t)
        {
            var ServerDetail = WebApiService.instance.PostAsync<ServerDetail>
                ("/api/ServerDetails/PostServerDetail", t, HttpContext.Current.User.Identity.Name).Result;
            return ServerDetail;
        }

        public ServerDetail Read(int id)
        {
            var ServerDetail = WebApiService.instance.GetAsync<ServerDetail>("/api/ServerDetails/GetServerDetail/" + id, HttpContext.Current.User.Identity.Name).Result;
            return ServerDetail;
        }

        public List<ServerDetail> ReadAll()
        {
            var ServerDetails = WebApiService.instance.GetAsync<List<ServerDetail>>("/api/ServerDetails/GetServerDetails", HttpContext.Current.User.Identity.Name).Result;
            return ServerDetails;
        }

        public bool Delete(ServerDetail t)
        {
            var ServerDetail = WebApiService.instance.DeleteAsync<ServerDetail>("/api/ServerDetails/DeleteServerDetail/" + t.Id, HttpContext.Current.User.Identity.Name).Result;
            return ServerDetail;
        }

        public bool Update(ServerDetail t)
        {
            var ServerDetail = WebApiService.instance.PutAsync<ServerDetail>("/api/ServerDetails/PutServerDetail/" + t.Id, t, HttpContext.Current.User.Identity.Name).Result;
            return ServerDetail;
        }

        public List<ServerDetail> ReadAllFromServer(int id)
        {
            var ServerDetail = WebApiService.instance.GetAsync<List<ServerDetail>>("/api/ServerDetails/GetServerDetailsFromServer/" + id, HttpContext.Current.User.Identity.Name).Result;
            return ServerDetail;
        }
    }
}