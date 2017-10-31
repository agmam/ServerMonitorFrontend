using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ServerMonitorFrontend
{
    public class ApiException : Exception
    {
        public ApiException(HttpStatusCode statusCode, string jsonData)
        {
            HttpStatusCode = statusCode;
            JsonData = jsonData;
        }

        public HttpStatusCode HttpStatusCode { get; set; }
        public string JsonData { get; set; }
    }
}