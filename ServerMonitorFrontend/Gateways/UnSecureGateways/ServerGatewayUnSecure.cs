using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Entities.Entities;

namespace ServerMonitorFrontend.Gateways
{
    public class ServerGatewayUnSecure : AServiceGateway<Server>
    {
        protected override Server CreatePost(Server t, HttpClient client)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("api/Servers/PostServer", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Server>().Result;
            }
            return null;
        }

        protected override Server ReadOne(int id, HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/Servers/GetServer/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Server>().Result;
            }
            return null;
        }

        protected override List<Server> ReadAllRead(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/Servers/GetServers").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<Server>>().Result;
            }
            return new List<ServerDetail>();
        }

        protected override bool DeleteDel(Server t, HttpClient client)
        {
            var response = client.DeleteAsync("/api/Servers/DeleteServer/" + t.Id).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        protected override bool UpdatePut(Server t, HttpClient client)
        {
            var response = client.PutAsJsonAsync("api/Servers/PutServer/" + t.Id, t).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        protected override List<Server> ReadAllFromServerRead(int id, HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/Servers/ReadAllFromServer/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<Server>>().Result;
            }
            return null;
        }
    }
}