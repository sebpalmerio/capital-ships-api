using Microsoft.AspNetCore.Mvc;
using ShipsAPI.Abstractions;
using ShipsAPI.Models.Tables;
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

        [HttpGet("GetShips")]
        public ActionResult<List<ShipModel>> GetShips()
        {
            return Ok(shipService.GetShips());
        }

        [HttpGet("GetBattles")]
        public ActionResult<List<BattleModel>> GetBattles()
        {
            return Ok(shipService.GetBattles());
        }

        [HttpGet("GetOutcomes")]
        public ActionResult<List<OutcomeModel>> GetOutcomes()
        {
            return Ok(shipService.GetOutcomes());
        }

        [HttpGet("GetClasses")]
        public ActionResult<List<ClassModel>> GetClasses()
        {
            return Ok(shipService.GetClasses());
        }

        [HttpGet("GetBattleNames")]
        public ActionResult<List<QueryModel>> GetBattleNames()
        {
            return Ok(shipService.Query());
        }

        [HttpGet("GetMaxSunkDisplacement")]
        public ActionResult<MaxSunkDisplacementModel> Get()
        {
            return Ok(shipService.MaxSunkDisplacement());
        }
    }

}