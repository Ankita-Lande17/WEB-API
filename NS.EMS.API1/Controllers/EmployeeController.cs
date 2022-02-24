using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.EMS.API1.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NS.EMS.API1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    { 

       
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employeeList = new List<Employee>();
            using (var context = new EmployeeDBContext())
            {
                employeeList= context.Employee.ToList();

            }
            return Ok(employeeList);
        }
        [HttpGet]
        public IActionResult GetEmployeeByEid(int eId)
        {
            var employee = new Employee();
            using (var context = new EmployeeDBContext())
            {
              employee = context.Employee.Find(eId);  
          }
            if(employee==null)
            {
                return NotFound("Employee Not found");
            }
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            using (var context = new EmployeeDBContext())
            {
                context.Employee.Add(employee);
                context.SaveChanges();

            }
            return Ok("Record Inserted Successfully");
        }
        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            using (var context = new EmployeeDBContext())
            {
                context.Employee.Update(employee);
                context.SaveChanges();

            }
            return Ok("Record Update Successfully");
        }
    }

}
