﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Entities;
using ServerMonitorFrontend.Logic;

namespace ServerMonitorFrontend.Models
{
    public class GraphModel
    {
        public List<GraphData> GraphDatas { get; set; }
        public List<ServerDetailAverage> Avarages { get; set; }
        public Server Server { get; set; }
    }
}