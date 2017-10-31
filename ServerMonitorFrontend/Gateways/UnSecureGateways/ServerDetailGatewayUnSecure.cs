using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Entities.Entities;

namespace ServerMonitorFrontend.Gateways
{
    public class ServerDetailGatewayUnSecure : AServiceGateway<ServerDetail>
    {
        protected override ServerDetail CreatePost(ServerDetail t, HttpClient client)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("api/ServerDetails/PostServerDetail", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<ServerDetail>().Result;
            }
            return null;
        }

        protected override ServerDetail ReadOne(int id, HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/ServerDetails/GetServerDetail/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<ServerDetail>().Result;
            }
            return null;
        }

        protected override List<ServerDetail> ReadAllRead(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/ServerDetails/GetServerDetails").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<ServerDetail>>().Result;
            }
            return new List<ServerDetail>();
        }

        protected override bool DeleteDel(ServerDetail t, HttpClient client)
        {
            var response = client.DeleteAsync("/api/ServerDetails/DeleteServerDetail/" + t.Id).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        protected override bool UpdatePut(ServerDetail t, HttpClient client)
        {
            var response = client.PutAsJsonAsync("api/ServerDetails/PutServerDetail/" + t.Id, t).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        protected override List<ServerDetail> ReadAllFromServerRead(int id, HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/ServerDetails/ReadAllFromServer/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<ServerDetail>>().Result;
            }
            return null;
        }
    }
}