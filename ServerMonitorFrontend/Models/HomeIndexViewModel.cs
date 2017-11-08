using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Entities;
using ServerMonitorFrontend.Logic;

namespace ServerMonitorFrontend.Models
{
    public class HomeIndexViewModel
    {
        public List<GraphData> GraphDatasCpu { get; set; }
        public List<GraphData> GraphDatasNetwork { get; set; }
        public List<ServerDetailAverage> Avarages { get; set; }
        public Server Server { get; set; }
        public List<Server> ServerList { get; set; }
        public ServerModel ServerModel { get; internal set; }
    }
}