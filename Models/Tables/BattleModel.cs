using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CapitalShipsAPI.Models.Tables
{
    public class BattleModel
    {
        public string Name { get; set; } // primary key
        public string Date { get; set; }
    }
}