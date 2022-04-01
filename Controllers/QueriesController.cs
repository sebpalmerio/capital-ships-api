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

        [HttpGet("GetBattleNames")]
        public ActionResult<List<QueryModel>> GetBattleNames()
        {
            return Ok(queryService.Query());
        }

        [HttpGet("GetMaxSunkDisplacement")]
        public ActionResult<MaxSunkDisplacementModel> Get()
        {
            return Ok(queryService.MaxSunkDisplacement());
        }
    }
}