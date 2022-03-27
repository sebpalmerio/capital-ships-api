using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CapitalShipsAPI.Models.Tables
{
    public class OutcomeModel
    {
        public string ShipName { get; set; }   // { 
                                               // primary key
        public string BattleName { get; set; } // }
        public string Result { get; set; }
    }
}