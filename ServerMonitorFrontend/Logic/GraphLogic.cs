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
        public List<GraphData> GetCpuGraphDatas(List<ServerDetailAverage> serverDetailAverages, int serverId)
        {
            List<GraphData> graphDatas = new List<GraphData>();

            foreach (var sa in serverDetailAverages)
            {
                //Sets properties for the GraphData
                GraphData gd = new GraphData()
                {
                    //Time created
                    x = sa.Created,
                    //Utilization of the CPU in %
                    y = sa.CPUUtilization
                };
                //Adds it to the list
                graphDatas.Add(gd);
            }
            //The average value for the dot in the graph
            decimal ave = 0;
            //Reads all the details of the server with serverId
            var detials = serverDetailGateway.ReadAllFromServer(serverId);
            //If we have some servers
            if (detials.Count > 0)
            {
                //We set the ave variable to the CPU utilization
                 ave = detials.Average(x => x.CPUUtilization);
            }
            //And sets the GraphData properties
            var graphData = new GraphData()
            {
                //Y-axis is the average cpu utilization in %
                y = ave,
                //The date time now is for plotting the data
                x = DateTime.Now
            };
            //Adding it to the list of graph datas
            graphDatas.Add(graphData);
            //And returns it
            return graphDatas;
        }
        public List<GraphData> GetNetworkGraphDatas(List<ServerDetailAverage> serverDetailAverages, int serverId)
        {
            List<GraphData> graphDatas = new List<GraphData>();

            foreach (var sa in serverDetailAverages)
            {
                GraphData gd = new GraphData()
                {
                    x = sa.Created,
                    y = sa.NetworkUtilization
                };
                graphDatas.Add(gd);
            }
            decimal ave = 0;
            var detials = serverDetailGateway.ReadAllFromServer(serverId);
            if (detials.Count > 0)
            {
                ave = detials.Average(x => x.NetworkUtilization);// Calculate average of the newest serverdetails for the latest graph dot
            }
            var graphData = new GraphData()
            {
                y = ave,
                x = DateTime.Now
            };
            graphDatas.Add(graphData);
            return graphDatas;
        }

        public List<GraphData> GetTemperatureGraphDatas(List<ServerDetailAverage> serverDetailAverages, int serverId)
        {
            List<GraphData> graphDatas = new List<GraphData>();

            foreach (var sa in serverDetailAverages)
            {
                GraphData gd = new GraphData()
                {
                    x = sa.Created,
                    y = sa.Temperature
                };
                graphDatas.Add(gd);
            }
            decimal ave = 0;
            var detials = serverDetailGateway.ReadAllFromServer(serverId);
            if (detials.Count > 0)
            {
                ave = detials.Average(x => x.Temperature);// Calculate average of the newest serverdetails for the latest graph dot
            }
            var graphData = new GraphData()
            {
                y = ave,
                x = DateTime.Now
            };
            graphDatas.Add(graphData);
            return graphDatas;
        }

       
    }
}