using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Entities.Entities;

namespace ServerMonitorFrontend.Gateways
{
    public class ServerDetailAverageGatewatUnSecure : AServiceGateway<ServerDetailAverage>
    {
        protected override ServerDetailAverage CreatePost(ServerDetailAverage t, HttpClient client)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("api/ServerDetailAverages/PostServerDetailAverage", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<ServerDetailAverage>().Result;
            }
            return null;
        }

        protected override ServerDetailAverage ReadOne(int id, HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/ServerDetailAverages/GetServerDetailAverage/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<ServerDetailAverage>().Result;
            }
            return null;
        }

        protected override List<ServerDetailAverage> ReadAllRead(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/ServerDetailAverages/GetServerDetailAverages").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<ServerDetailAverage>>().Result;
            }
            return new List<ServerDetailAverage>();
        }

        protected override bool DeleteDel(ServerDetailAverage t, HttpClient client)
        {
            var response = client.DeleteAsync("/api/ServerDetailAverages/DeleteServerDetailAverage/" + t.Id).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        protected override bool UpdatePut(ServerDetailAverage t, HttpClient client)
        {
            var response = client.PutAsJsonAsync("api/ServerDetailAverages/PutServerDetailAverage/" + t.Id, t).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        protected override List<ServerDetailAverage> ReadAllFromServerRead(int id, HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/ServerDetailAverages/ReadAllFromServer/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<ServerDetailAverage>>().Result;
            }
            return null;
        }
    }
}