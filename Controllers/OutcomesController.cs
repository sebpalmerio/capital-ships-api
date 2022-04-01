using Microsoft.AspNetCore.Mvc;
using CapitalShipsAPI.Abstractions;
using CapitalShipsAPI.Models.Tables;
using System;
using System.Collections.Generic;

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
            return Ok(outcomeService.GetOutcomes());
        }

        [HttpPost("InsertOutcome")]
        public IActionResult Post([FromBody] OutcomeModel entity)
        {
            outcomeService.AddOutcomeModel(entity);
            return CreatedAtAction(nameof(Get), entity);
        }

        [HttpDelete("DeleteOutcome")]
        public IActionResult Delete3([FromQuery] string Name)
        {
            outcomeService.DeleteOutcomeModel(Name);
            return Ok("Outcome deleted");
        }
    }
}