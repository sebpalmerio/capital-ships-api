using Microsoft.AspNetCore.Mvc;
using CapitalShipsAPI.Abstractions;
using CapitalShipsAPI.Models.Tables;
using System;
using System.Collections.Generic;

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
            return Ok(battleService.GetBattles());
        }

        [HttpPost("InsertBattle")]
        public IActionResult Post([FromBody] BattleModel entity)
        {
            battleService.AddBattleModel(entity);
            return CreatedAtAction(nameof(Get), entity);
        }

        [HttpPut("UpdateBattle")]
        public IActionResult Put(string BattleName, string NewBattleName)
        {
            battleService.UpdateBattleModel(BattleName, NewBattleName);
            return Ok($"{BattleName} updated to {NewBattleName}");
        }

        [HttpDelete("DeleteBattle")]
        public IActionResult Delete2([FromQuery] string Name)
        {
            battleService.DeleteBattleModel(Name);
            return Ok("Battle deleted");
        }
    }
}