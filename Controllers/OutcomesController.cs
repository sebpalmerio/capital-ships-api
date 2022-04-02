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
    public class OutcomesController : ControllerBase
    {
        private readonly IOutcomeService outcomeService;
        public OutcomesController(IOutcomeService _outcomeService)
        {
            outcomeService = _outcomeService ?? throw new ArgumentNullException(nameof(_outcomeService));
        }

        [HttpGet("GetOutcomes")]
        public ActionResult<List<OutcomeModel>> Get()
        {
            Log.Debug("Fetching outcome models");
            try
            {
                Log.Information("Fetch successful");
                return Ok(outcomeService.GetOutcomes());
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Fetch failed");
            }
        }

        [HttpPost("InsertOutcome")]
        public IActionResult Post([FromBody] OutcomeModel entity)
        {
            Log.Debug($"Adding outcome with {entity.ShipName} in {entity.BattleName}");
            try
            {
                Log.Information("Add successful");
                outcomeService.AddOutcomeModel(entity);
                return CreatedAtAction(nameof(Get), entity);
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Add failed");
            }
        }

        [HttpDelete("DeleteOutcome")]
        public IActionResult Delete([FromQuery] string Name)
        {
            Log.Debug($"Deleting {Name}");
            try
            {
                outcomeService.DeleteOutcomeModel(Name);
                return Ok("Outcome deleted");
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Delete failed");
            }
        }
    }
}