﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Server 
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string ServerName { get; set; }
        public List<Event> Events { get; set; }
        public List<ServerDetail> ServerDetails { get; set; }
        public List<ServerDetailAverage> ServerDetailAverages { get; set; }
    }
}
