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
    public class ClassesController : ControllerBase
    {
        private readonly IClassService classService;
        public ClassesController(IClassService _classService)
        {
            classService = _classService ?? throw new ArgumentNullException(nameof(_classService));
        }

        [HttpGet("GetClasses")]
        public ActionResult<List<ClassModel>> Get()
        {
            Log.Debug("Fetching class models");
            try
            {
                Log.Information("Fetch successful");
                return Ok(classService.GetClasses());
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Fetch failed");
            }
        }

        [HttpPost("InsertClass")]
        public IActionResult Post([FromBody] ClassModel entity)
        {
            Log.Debug($"Adding {entity.ClassName} class");
            try
            {
                Log.Information("Add successful");
                classService.AddClassModel(entity);
                return CreatedAtAction(nameof(Get), entity);
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Add failed");
            }
        }

        [HttpPut("UpdateClass")]
        public IActionResult Put(string ClassName, string NewClassName)
        {
            Log.Debug($"Updating {ClassName}");
            try
            {
                classService.UpdateClassModel(ClassName, NewClassName);
                return Ok($"{ClassName} updated to {NewClassName}");
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Update failed");
            }
        }

        [HttpDelete("DeleteClass")]
        public IActionResult Delete([FromQuery] string Name)
        {
            Log.Debug($"Deleting {Name}");
            try
            {
                classService.DeleteClassModel(Name);
                return Ok("Class deleted");
            }
            catch (Exception ex)
            {
                Log.Warning($"{ex.Message}");
                return BadRequest("Delete failed");
            }
        }
    }
}