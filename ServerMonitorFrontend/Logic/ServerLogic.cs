using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Entities;
using ServerMonitorFrontend.Gateways;

namespace ServerMonitorFrontend.Models
{
    public class ServerLogic
    {
        private readonly IServerGateway serverGateway =
            new BLLFacade().GetServerGateway();

        private readonly IServiceGateway<ServerDetail> serverDetailsDB = new BLLFacade().GetServerDetailGateway();

        public ServerModel getServerModel(int serverId)
        {
            ServerModel serverModel = new ServerModel();

            Server server = serverGateway.Read(serverId);
            serverModel.Server = server;

            var serverDetails = serverDetailsDB.ReadAllFromServer(server.Id);
            if (serverDetails.LastOrDefault(x => x.Created > DateTime.Now.AddSeconds(-30)) != null)
            {
                //Server up
                serverModel.ServerUp = true;
                var latestServerDetail = serverDetails.LastOrDefault() ?? new ServerDetail();
                serverModel.CurrentTemperature = latestServerDetail.Temperature;
                serverModel.RAMTotal = latestServerDetail.RAMTotal;
                serverModel.BytesReceived = latestServerDetail.BytesReceived;
                serverModel.BytesSent = latestServerDetail.BytesSent;
                serverModel.Handles = latestServerDetail.Handles;
                serverModel.Processes = latestServerDetail.Processes;
                serverModel.RAMAvailable = latestServerDetail.RAMAvailable;
                serverModel.DataReceived = latestServerDetail.Created;
                serverModel.UpTime = CalculateUpTime(latestServerDetail.UpTime);
            }
            else
            {
                //Server down
                serverModel.DataReceived =DateTime.Now;
                serverModel.ServerUp = false;
            }



            return serverModel;
        }
        public string CalculateUpTime(decimal sec)
        {
            string uptimeString = "";
            try
            {
                long seconds = Convert.ToInt64(sec);
                long minute = (seconds / 60) % 60;
                long hour = (seconds / 60 / 60) % 24;
                long days = (seconds / 60 / 60 / 24);

                uptimeString = days + " days " + hour + " hours " + minute + " minutes";
            }
            catch (Exception e)
            {
              //  log.Error("ServerLogic - CalculateUpTime: ", e);
            }

            return uptimeString;
        }
    }
}