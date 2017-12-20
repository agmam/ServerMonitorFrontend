﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace ServerMonitorFrontend.Gateways
{
    public class WebApiService
    {
        private WebApiService(string baseUri)
        {
            BaseUri = baseUri;
        }

        private static WebApiService _instance;
        public string BaseUri { get; private set; }

        public static WebApiService instance
        {
            get
            {
                return _instance ?? (_instance = new WebApiService(ConfigurationManager.AppSettings["WebApiUri"]));
            }
        }
        public async Task<T> AuthedicateAsync<T>(string userName, string password)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var result =
                        await
                            client.PostAsync(ActionUri("/Token"),
                                new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                                {
                                new KeyValuePair<string, string>("grant_type", "password"),
                                new KeyValuePair<string, string>("userName", userName),
                                new KeyValuePair<string, string>("password", password)
                                }));
                    return await DeserializeObject<T>(result);
                }
            }
            catch (Exception e)
            {

                return default(T);
            }
        }

        private static async Task<T> DeserializeObject<T>(HttpResponseMessage result)
        {

            try
            {
                string json = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(json);
                }
                return default(T);
            }
            catch (Exception e)
            {

                return default(T);
            }
            
        }

        private string ActionUri(string action)
        {
            var c = BaseUri + action;
            return c;
        }

        public async Task<T> GetAsync<T>(string action, string authToken = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    SetAuthHeader(authToken, client);
                    var result = client.GetAsync(ActionUri(action)).Result;
                    return await DeserializeObject<T>(result);
                }
            }
            catch (Exception e)
            {
                return default(T);
            }

        }

        private static void SetAuthHeader(string authToken, HttpClient client)
        {
            if (!authToken.IsNullOrWhiteSpace())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + authToken);
            }
        }

        public async Task<bool> PutAsync<T>(string action, T data, string authToken = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    SetAuthHeader(authToken, client);
                    var result = client.PutAsJsonAsync(ActionUri(action), data).Result;
                    string json = await result.Content.ReadAsStringAsync();
                    if (result.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<T> PostAsync<T>(string action, T data, string authToken = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    SetAuthHeader(authToken, client);
                    var result = client.PostAsJsonAsync(ActionUri(action), data).Result;
                    return await DeserializeObject<T>(result);
                }
            }
            catch (Exception)
            {

                return default(T);
            }
        }

        public async Task<bool> DeleteAsync<T>(string action, string authToken = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    SetAuthHeader(authToken, client);
                    var result = client.DeleteAsync(ActionUri(action)).Result;
                    string json = await result.Content.ReadAsStringAsync();
                    if (result.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}