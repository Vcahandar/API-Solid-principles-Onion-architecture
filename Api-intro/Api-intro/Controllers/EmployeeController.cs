using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api_intro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult  GetAll()
        {
            string[] names = { "Eli", "Jale", "Pervin" };
            return Ok(names);
        }


        [HttpGet]
        public IActionResult GetById(int? id)
        {
            if (id == null) return BadRequest();
            return Ok("Eli - " + "" + id);
        }
    }
}
