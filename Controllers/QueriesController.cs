using Microsoft.AspNetCore.Mvc;
using CapitalShipsAPI.Abstractions;
using CapitalShipsAPI.Models.Queries;
using System;
using System.Collections.Generic;

namespace CapitalShipsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueryController : ControllerBase
    {
        private readonly IQueryService queryService;
        public QueryController(IQueryService _queryService)
        {
            queryService = _queryService ?? throw new ArgumentNullException(nameof(_queryService));
        }

        [HttpGet("GetMaxSunkDisplacement")]
        public ActionResult<MaxSunkDisplacementModel> GetMaxSunkDisplacementShip()
        {
            return Ok(queryService.MaxSunkDisplacement());
        }

        [HttpGet("GetGuadalcanalGunSums")]
        public ActionResult<GuadalcanalSumModel> GetGuadalcanalGunSums()
        {
            return Ok(queryService.GuadalcanalSums());
        }

        [HttpGet("GetClassesInEveryBattle")]
        public ActionResult<GuadalcanalSumModel> GetClassesInEveryBattle()
        {
            return Ok(queryService.ClassesInEveryBattle());
        }
    }
}