using Microsoft.AspNetCore.Mvc;
using CapitalShipsAPI.Abstractions;
using CapitalShipsAPI.Models.Tables;
using CapitalShipsAPI.Models.Queries;
using System;
using System.Linq;
using System.Collections.Generic;

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
            return Ok(classService.GetClasses());
        }

        [HttpPost("InsertClass")]
        public IActionResult Post([FromBody] ClassModel entity)
        {
            classService.AddClassModel(entity);
            return CreatedAtAction(nameof(Get), entity);
        }

        [HttpPut("UpdateClass")]
        public IActionResult Put([FromBody] string ClassName, string NewClassName)
        {
            classService.UpdateClassModel(ClassName, NewClassName);
            return Ok($"{ClassName} updated to {NewClassName}");
        }

        [HttpDelete("DeleteClass")]
        public IActionResult Delete4([FromQuery] string Name)
        {
            classService.DeleteClassModel(Name);
            return Ok("Class deleted");
        }
    }
}