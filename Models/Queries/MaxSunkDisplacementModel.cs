using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ShipsAPI.Models.Queries
{
    public class MaxSunkDisplacementModel
    {
        public string ShipName { get; set; }
        public string BattleName { get; set; }
        public string Date { get; set; }
    }
}