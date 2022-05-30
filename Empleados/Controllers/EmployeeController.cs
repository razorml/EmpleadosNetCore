using Empleados.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Empleados.Repositories;

namespace Empleados.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        public EmployeeRepositories employee { get; set; }
        public EmployeeController(IConfiguration configuration) 
        {
            employee = new EmployeeRepositories(configuration);
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public ActionResult<List<Employees>> GetAllEmployees() 
        {
            var result = employee.LoadListEmployees();
            return new ObjectResult(new { result }) { StatusCode = 200 };
        }

        [HttpGet]
        [Route("GetEmployeeId/{id}")]
        public ActionResult<List<Employees>> GetEmployeeId(int id)
        {
            var result = employee.LoadListEmployeeId(id);
            return new ObjectResult(new { result }) { StatusCode = 200 };
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public ActionResult<IList<Employees>> CreateEmployee(Employees employees)
        {
            var result = employee.CreateEmployee(employees);
            return new ObjectResult(new { result }) { StatusCode = 200 };
        }

        [HttpPut]
        [Route("UpdateEmployee/{idEmployee}/{userName}")]
        public ActionResult<IList<Employees>> UpdateEmployee(int idEmployee, string userName)
        {
            var result = employee.UpdateEmployee(idEmployee, userName);
            return new ObjectResult(new { result }) { StatusCode = 200 };
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public ActionResult<IList<Employees>> DeleteEmployee(int idEmployee)
        {
            var result = employee.DeleteEmployee(idEmployee);
            return new ObjectResult(new { result }) { StatusCode = 200 };
        }
    }
}

