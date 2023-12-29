using BasicAuth.BasicAuth;
using BasicAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicAuth.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    [TokenAuthenticationFilter]
    public class EmployeesController : ControllerBase
    {
        [HttpGet("GetEmployees")]
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee() { Id = 1, FirstName = "Yogesh", LastName= "Kumar", Gender = "Male", City = "Delhi", IsActive = true },
                 new Employee() { Id = 1, FirstName = "Sudesh", LastName= "Kumar", Gender = "Male", City = "Delhi", IsActive = true },
                  new Employee() { Id = 1, FirstName = "Rajesh", LastName= "Kumar", Gender = "Male", City = "Delhi", IsActive = true },
                   new Employee() { Id = 1, FirstName = "Pravesh", LastName= "Kumar", Gender = "Male", City = "Delhi", IsActive = true }
            };

            //var employees = Employee.GetEmployee(); ;
            return employees;
        }
    }
}
