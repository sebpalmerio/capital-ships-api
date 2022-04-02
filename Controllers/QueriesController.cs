using Microsoft.AspNetCore.Mvc;
using CapitalShipsAPI.Abstractions;
using CapitalShipsAPI.Models.Queries;
using System;
using System.Collections.Generic;
using Serilog;

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
            Log.Debug("Fetching ship with max displacement that was sunk in battle");
            try
            {
                Log.Information("Fetch successful");
                return Ok(queryService.MaxSunkDisplacement());
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Fetch failed");
            }
        }

        [HttpGet("GetGuadalcanalGunSums")]
        public ActionResult<GuadalcanalSumModel> GetGuadalcanalGunSums()
        {
            Log.Debug("Fetching the number of guns in US and Japanese used in Guadalcanal");
            try
            {
                Log.Information("Fetch successful");
                return Ok(queryService.GuadalcanalSums());
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Fetch failed");
            }
        }

        [HttpGet("GetClassesInEveryBattle")]
        public ActionResult<List<string>> GetClassesInEveryBattle()
        {
            Log.Debug("Fetching classes that participated in every battle");
            try
            {
                Log.Information("Fetch successful");
                return Ok(queryService.ClassesInEveryBattle());
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Fetch failed");
            }
        }
    }
}