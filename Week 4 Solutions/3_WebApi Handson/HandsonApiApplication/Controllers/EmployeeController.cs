using Handson.Models;
using Handson.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Handson.Controllers
{
    [ApiController]
    [Route("api/Emp")]
    [CustomAuthFilter]
    public class EmployeeController : ControllerBase
    {
        private List<Employee> _employees;

        public EmployeeController()
        {
            _employees = GetStandardEmployeeList(); // populate with sample data
        }

        // 🔹 Private method that returns dummy employee data
        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Name = "Alice",
                    Salary = 60000,
                    Permanent = true,
                    Department = new Department { Id = 1, Name = "IT" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 101, Name = "C#" },
                        new Skill { Id = 102, Name = "SQL" }
                    },
                    DateOfBirth = new DateTime(1990, 3, 14)
                },
                new Employee
                {
                    Id = 2,
                    Name = "Bob",
                    Salary = 50000,
                    Permanent = false,
                    Department = new Department { Id = 2, Name = "HR" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 103, Name = "Communication" },
                        new Skill { Id = 104, Name = "Recruitment" }
                    },
                    DateOfBirth = new DateTime(1985, 6, 20)
                }
            };
        }

        // 🔹 GET: api/employee
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<List<Employee>> GetStandard()
        {
            return Ok(_employees);
        }

        // 🔹 POST: api/employee
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            _employees.Add(employee);
            return CreatedAtAction(nameof(GetStandard), new { id = employee.Id }, employee);
        }

        // 🔹 PUT: api/employee/{id}
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
        {
            var existing = _employees.Find(e => e.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = employee.Name;
            existing.Salary = employee.Salary;
            existing.Permanent = employee.Permanent;
            existing.Department = employee.Department;
            existing.Skills = employee.Skills;
            existing.DateOfBirth = employee.DateOfBirth;

            return Ok(existing);
        }

        // 🔹 GET: api/employee/throw — to trigger exception
        [HttpGet("throw")]
        [ProducesResponseType(500)]
        public IActionResult ThrowException()
        {
            throw new Exception("Test exception for custom exception filter");
        }
    }
}
