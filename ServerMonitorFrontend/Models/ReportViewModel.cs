using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Entities;

namespace ServerMonitorFrontend.Models
{
    public class ReportViewModel
    {

        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public string ServerName { get; set; }
        public List<Event> Events { get; set; }
        public List<EventType> Types { get; set; }
        public double AverageResponseTime { get; set; }
        public double AverageCpuUtilization { get; set; }
        public List<DailySummary> DailySummaries { get; set; }
        public List<Server> Servers { get; set; }

        
    }

    public class DailySummary
    {
        public DateTime Day { get; set; }
        public List<Event> DailyEvents { get; set; }
    }
}