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
    public class BattlesController : ControllerBase
    {
        private readonly IBattleService battleService;
        public BattlesController(IBattleService _battleService)
        {
            battleService = _battleService ?? throw new ArgumentNullException(nameof(_battleService));
        }

        [HttpGet("GetBattles")]
        public ActionResult<List<BattleModel>> Get()
        {
            Log.Debug("Fetching battle models");
            try
            {
                Log.Information("Fetch successful");
                return Ok(battleService.GetBattles());
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Fetch failed");
            }
        }

        [HttpPost("InsertBattle")]
        public IActionResult Post([FromBody] BattleModel entity)
        {
            Log.Debug($"Adding {entity.Name} battle");
            try
            {
                Log.Information("Add successful");
                battleService.AddBattleModel(entity);
                return CreatedAtAction(nameof(Get), entity);
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Add failed");
            }
        }

        [HttpPut("UpdateBattle")]
        public IActionResult Put(string BattleName, string NewBattleName)
        {
            Log.Debug($"Updating {BattleName}");
            try
            {
                Log.Information("Update successful");
                battleService.UpdateBattleModel(BattleName, NewBattleName);
                return Ok($"{BattleName} updated to {NewBattleName}");
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Update failed");
            }
        }

        [HttpDelete("DeleteBattle")]
        public IActionResult Delete([FromQuery] string Name)
        {
            Log.Debug($"Deleting {Name}");
            try
            {
                Log.Information("Delete successful");
                battleService.DeleteBattleModel(Name);
                return Ok("Battle deleted");
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Delete failed");
            }
        }
    }
}