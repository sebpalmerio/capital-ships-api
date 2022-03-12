using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ShipsAPI.Models
{
    public class ShipModel
    {
        public string Name { get; set; } // primary key
        public string Class { get; set; }
        public int Launched { get; set; }
    }
}