using Microsoft.AspNetCore.Mvc;
using ShipsAPI.Abstractions;
using ShipsAPI.Models.Queries;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ShipsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipController : ControllerBase
    {
        private readonly IShipService shipService;
        public ShipController(IShipService _shipService)
        {
            shipService = _shipService ?? throw new ArgumentNullException(nameof(_shipService));
        }

        [HttpGet(Name = "GetBattleNames")]
        public ActionResult<List<QueryModel>> Get()
        {
            return Ok(shipService.Query());
        }
    }

}