using AutoMapperSample.Models;
using AutoMapperSample.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;

        public StudentController(IStudentRepo studentRepo) 
        {
            _studentRepo = studentRepo;
        }

        [HttpGet("GetAllStudent")]
        public async Task<IActionResult> GetAll()
        {            
            List<StudentDTO> stdList = await _studentRepo.GetStudent();
            if(stdList != null)
            {
                return Ok(stdList);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("AddValue")]
        public async Task<IActionResult> Addition()
        {
            var a = await _studentRepo.Task1();
            var b = await _studentRepo.Task2();
            var c = await _studentRepo.Task3();

            //await Task.WhenAll(a, b, c);            
            return Ok(a + b + c);
        }
    }
}
