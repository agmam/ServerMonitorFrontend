using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Entities;
using ServerMonitorFrontend.Logic;

namespace ServerMonitorFrontend.Models
{
    public class ServerModel
    {
        public decimal RAMAvailable { get; set; }
        public decimal BytesReceived { get; set; }
        public decimal BytesSent { get; set; }
        public decimal Handles { get; set; }
        public decimal Processes { get; set; }
        public decimal Threads { get; set; }
        public decimal RAMTotal { get; set; }
        public Server Server { get; set; }
        public bool ServerUp { get; set; }
        public decimal CurrentTemperature { get; set; }
        public DateTime DataReceived { get; internal set; }
        public string UpTime { get; set; }
    }
}