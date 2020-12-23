using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDappWebAPIVersion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDappWebAPIVersion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployee _objEmployee;
        public EmployeeController(IEmployee EmployeeAccessLayer)
        {
            this._objEmployee = EmployeeAccessLayer;
        }

        [HttpPost]
        public void AddEmployee([FromBody]Employee employee)
        {
            this._objEmployee.AddEmployee(employee);

        }

         [HttpGet]
        //[HttpGet(Name = "GetAllEmployees")]
        //[Route("api/[controller]")]
        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = this._objEmployee.GetEmployees().ToList();
            return employees;
            
        }

        [HttpGet("{id}")]
        public Employee GetEmployee(Guid id)
        {
            var employee = this._objEmployee.GetEmployee(id);
            return employee;

        }

        [HttpDelete("{id}")]
        //[HttpDelete]
        //[Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployeebyId(Guid id)
        {
            var employee = this._objEmployee.GetEmployee(id);

            if (employee != null)
            {
                this._objEmployee.DeleteEmployee(employee);
                return Ok();
            }
            return NotFound($"Employee with ID: {id} is not found");
            
            //if(id != null)
            //{
            //    this._objEmployee.DeleteEmployee(id);
            //}
            //return NotFound($"Employee with ID: {id} is not found");
        }


        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(Guid id, [FromBody]Employee employee)
        {
            var existingEmployee = this._objEmployee.GetEmployee(id);

            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Department = employee.Department;
                existingEmployee.City = employee.City;

                this._objEmployee.UpdateEmployee(employee);
                return Ok($"Employee with ID: {id} is updated");
            }
            return NotFound($"Employee with ID: {id} is not found");

        }

    }

    
}