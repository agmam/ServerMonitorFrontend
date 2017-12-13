using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Entities;
using ServerMonitorFrontend.Gateways;
using ServerMonitorFrontend.Models;

namespace ServerMonitorFrontend.Logic
{
    public class ReportLogic
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IServerDetailAverageGateway serverDetailAverageGateway =
            new BLLFacade().GetServerDetailAverageGateway();

        private readonly IServerGateway serverGateway =
            new BLLFacade().GetServerGateway();
        private readonly IEventGateway eventGateway =
            new BLLFacade().GetEventGateway();

        public ReportViewModel GenerateViewModel(DateTime from, DateTime to, int serverId)
        {
            ReportViewModel rvm = new ReportViewModel();
            try
            {
                Server s = serverGateway.Read(serverId);
                //tjek om to date er i dag. i så fald plus en dag så alt data fra i dag kommer med(ellers tager den fra 00:00)
                if (to.Date == DateTime.Today)
                {
                    to = to.AddDays(1);
                }

                List<Event> events = eventGateway.GetAllEventsByRange(from, to, serverId);
                List<EventType> types = events.Select(x => x.EventType).ToList();



                List<DailySummary> dailySummaries = new List<DailySummary>();

                //Liste med datoer der er sket events
                List<DateTime> dates = new List<DateTime>();
                foreach (var e in events)
                {
                    if (dates.FirstOrDefault(x => x.Day == e.Created.Day && x.Month == e.Created.Month && x.Year == e.Created.Year) != default(DateTime))
                    {
                        //Find summary and add
                        DailySummary summary = dailySummaries.FirstOrDefault(x => x.Day.Day == e.Created.Day && x.Day.Month == e.Created.Month && x.Day.Year == e.Created.Year);
                        summary?.DailyEvents.Add(e);

                    }
                    else
                    {
                        dates.Add(e.Created);
                        DailySummary d = new DailySummary()
                        {
                            Day = e.Created,
                            DailyEvents = new List<Event>()
                        };
                        d.DailyEvents.Add(e);
                        dailySummaries.Add(d);
                    }

                }

                rvm.DailySummaries = dailySummaries;

                rvm.ServerName = s.ServerName;
                rvm.Types = types;
                rvm.to = to;
                rvm.from = from;
                rvm.Events = events;

            }
            catch (Exception e)
            {
                log.Error("GetReport: " + e);
            }

            return rvm;
        }
        public static string MinutesToDateString(int minutes)
        {
            long minute = minutes % 60;
            long hour = (minutes / 60) % 24;
            long days = (minutes / 60 / 24) % 24;

            string uptimeString = days + " days " + hour + " hours " + minute + " minutes";

            return uptimeString;
        }
    }
}