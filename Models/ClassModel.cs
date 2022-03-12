using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ShipsAPI.Models
{
    public class ClassModel
    {
        public string ClassName { get; set; } // primary key
        public string Type { get; set; }
        public string Country { get; set; }
        public int numGun { get; set; }
        public int Bore { get; set; }
        public int Displacement { get; set; }
    }
}