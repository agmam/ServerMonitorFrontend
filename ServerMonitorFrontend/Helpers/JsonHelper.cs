using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ServerMonitorFrontend.Helpers
{
    public static class JsonHelper
    {
        public static HtmlString JsonInsert(this HtmlHelper html, object o)
        {
            var json = JsonConvert.SerializeObject(o, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            return new HtmlString(json);
        }


    }
}