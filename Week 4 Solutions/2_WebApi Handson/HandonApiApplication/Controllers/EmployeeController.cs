using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Handson.Controllers
{
    [ApiController]
    [Route("api/Emp")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var employees = new List<string>
            {
                "John Doe",
                "Jane Smith",
                "Michael Johnson"
            };

            return Ok(employees);
        }
    }
}
