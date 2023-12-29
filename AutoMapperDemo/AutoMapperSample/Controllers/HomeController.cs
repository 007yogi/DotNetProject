using AutoMapperSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
            
        }
        /// <summary>
        /// Get Student without using auto-mapper
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetStudent")]
        public Student GetStudent()
        {
            StudentDTO objDTO = new StudentDTO
            {
                Name = "Ram",
                Age = 30,
                City = "Delhi"
            };

            Student obj = new Student()
            {
                Name = objDTO.Name,
                Age = objDTO.Age,
                City = objDTO.City,
            };

            return obj;
        }
    }
}
