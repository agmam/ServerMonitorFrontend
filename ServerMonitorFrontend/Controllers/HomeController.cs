﻿using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Entities.Entities;
using ServerMonitorFrontend.Gateways;
using ServerMonitorFrontend.Logic;
using ServerMonitorFrontend.Models;

namespace ServerMonitorFrontend.Controllers
{

    public class HomeController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IServiceGateway<ServerDetail> sd = new BLLFacade().GetServerDetailGateway();

        private readonly IServerDetailAverageGateway serverDetailAverageGateway =
            new BLLFacade().GetServerDetailAverageGateway();

        private readonly IServerGateway serverGateway =
            new BLLFacade().GetServerGateway();
        private readonly IServiceGateway<Event> eventGateway =
            new BLLFacade().GetEventGateway();
        [Authorize]
        public ActionResult Index(int id = 1)
        {HomeIndexViewModel model = new HomeIndexViewModel();
            try { 
            var server = serverGateway.ReadAll().FirstOrDefault();
            
            if (server != null)
            {
                 model = GenerateViewModel(server.Id);
            }
            
            return View(model);
            }
            catch (Exception e)
            {
                model.ServerModel = new ServerModel();
                model.Events = new List<Event>();
                model.ServerList = new List<Server>();
                model.ServerModel.Server = new Server();
                model.GraphDatasCpu = new List<GraphData>();
                model.GraphDatasNetwork = new List<GraphData>();
                model.GraphDatasTemperature = new List<GraphData>();


                return View(model);
            }
        }

        [Authorize]
        private HomeIndexViewModel GenerateViewModel(int id)
        {
            var serverLogic = new ServerLogic();
            var serverModel = serverLogic.getServerModel(id);

            List<Server> servers = serverGateway.ReadAll();
            var list = serverDetailAverageGateway.GetAllServerDetailAveragesForPeriod(24, serverModel.Server.Id);


            var graphLogic = new GraphLogic();
            var graphdatas = graphLogic.GetCpuGraphDatas(list, serverModel.Server.Id);
            var netGraphDatas = graphLogic.GetNetworkGraphDatas(list, serverModel.Server.Id);
            var tempGraphData = graphLogic.GetTemperatureGraphDatas(list, serverModel.Server.Id);
            var events = eventGateway.ReadAllFromServer(serverModel.Server.Id);

            var model = new HomeIndexViewModel()
            {
                GraphDatasCpu = graphdatas,
                GraphDatasNetwork = netGraphDatas,
                GraphDatasTemperature = tempGraphData,
                Avarages = list,
                ServerList = servers,
                ServerModel = serverModel,
                Events = events
                
            };
            return model;
        }

        [Authorize]
        [HttpGet]
        [Route("home/GetServerModel/{serverId}")]
        public ActionResult GetServerModel(int serverId)
        {
            return Json(GenerateViewModel(serverId), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        [Route("home/GetEventPartialView/{serverId}")]
        public ActionResult GetEventPartialView(int serverId)
        {
            List<Event> events = eventGateway.ReadAllFromServer(serverId);
            return PartialView("~/Views/Home/_EventDetail.cshtml", events) ;
        }
        

        public string SendMailTest()
        {
            string m = "Hej";
            List<string> receivers = new List<string>() {
                "Esben.laursen@gmail.com","ag-mam@live.dk"
               
            };
            try
            {
                using (var client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync("http://localhost:63735/api/Home", receivers).Result;
                    //try
                    //{
                    //    string json = await result.Content.ReadAsStringAsync();
                    //    if (result.IsSuccessStatusCode)
                    //    {
                    //        return JsonConvert.DeserializeObject<T>(json);
                    //    }
                    //    return default(T);
                    //}
                    //catch (Exception e)
                    //{

                    //    return default(T);
                    //}
                }
                return "sent fag";
            }
            catch (Exception)
            {

                return "nope";
            }

         
            
        }
       


    }
}