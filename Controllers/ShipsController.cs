using Microsoft.AspNetCore.Mvc;
using CapitalShipsAPI.Abstractions;
using CapitalShipsAPI.Models.Tables;
using System;
using System.Collections.Generic;
using Serilog;

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
            Log.Debug("Fetching ship models");
            try
            {
                Log.Information("Fetch successful");
                return Ok(shipService.GetShips());
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Fetch failed");
            }
        }

        [HttpPost("InsertShip")]
        public IActionResult Post([FromBody] ShipModel entity)
        {
            Log.Debug($"Adding {entity.Name} ship");
            try
            {
                Log.Information("Add successful");
                shipService.AddShipModel(entity);
                return CreatedAtAction(nameof(Get), entity);
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Add failed");
            }
        }

        [HttpPut("UpdateShip")]
        public IActionResult Put(string ShipName, string NewShipName)
        {
            Log.Debug($"Updating {ShipName}");
            try
            {
                Log.Information("Update successful");
                shipService.UpdateShipModel(ShipName, NewShipName);
                return Ok($"{ShipName} updated to {NewShipName}");
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Update failed");
            }
        }

        [HttpDelete("DeleteShip")]
        public IActionResult Delete([FromQuery] string Name)
        {
            Log.Debug($"Deleting {Name}");
            try
            {
                Log.Information("Delete successful");
                shipService.DeleteShipModel(Name);
                return Ok("Ship deleted");
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Delete failed");
            }
        }
    }
}