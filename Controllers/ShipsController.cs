using Microsoft.AspNetCore.Mvc;
using CapitalShipsAPI.Abstractions;
using CapitalShipsAPI.Models.Tables;
using CapitalShipsAPI.Models.Queries;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CapitalShipsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipController : ControllerBase
    {
        private readonly IShipService shipService;
        public ShipController(IShipService _shipService)
        {
            shipService = _shipService ?? throw new ArgumentNullException(nameof(_shipService));
        }

        [HttpGet("GetShips")]
        [ActionName(nameof(Get))]
        public ActionResult<List<ShipModel>> Get()
        {
            return Ok(shipService.GetShips());
        }

        [HttpPost("InsertShip")]
        public IActionResult Post([FromBody] ShipModel entity)
        {
            shipService.AddShipModel(entity);
            return CreatedAtAction(nameof(Get), entity);
        }

        [HttpDelete("DeleteShip")]
        public IActionResult Delete([FromQuery] string Name)
        {
            shipService.DeleteShipModel(Name);
            return Ok("Ship deleted");
        }
    }
}