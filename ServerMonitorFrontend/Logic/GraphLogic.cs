using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Entities;
using ServerMonitorFrontend.Gateways;

namespace ServerMonitorFrontend.Logic
{
    public class GraphLogic
    {
        private readonly IServiceGateway<ServerDetail> serverDetailGateway = new BLLFacade().GetServerDetailGateway();
        public List<GraphData> GetCpuGraphDatas(List<ServerDetailAverage> serverDetailAverages)
        {
            List<GraphData> graphDatas = new List<GraphData>();

            foreach (var sa in serverDetailAverages)
            {
                GraphData gd = new GraphData()
                {
                    X = sa.Created,
                    Y = sa.CPUUtilization
                };
                graphDatas.Add(gd);
            }
            var detials = serverDetailGateway.ReadAll();
            var ave = detials.Average(x=> x.CPUUtilization);// udregner gennemsnittet af de nyeste serverdetails for det seneste graf punkt
            var graphData = new GraphData()
            {
                Y = ave,
                X = DateTime.Now
            }; 
            graphDatas.Add(graphData);
            return graphDatas;
        }
    }
}