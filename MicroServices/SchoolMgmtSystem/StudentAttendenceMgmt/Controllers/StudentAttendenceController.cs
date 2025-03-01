using Microsoft.AspNetCore.Mvc;
using StudentAttendenceMgmt.Models;

namespace StudentAttendenceMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAttendenceController : ControllerBase
    {
        public static List<StudentAttendenceDTO> stdLst = new List<StudentAttendenceDTO>
        {
            new StudentAttendenceDTO{Id = 1, StudentName = "Poonam Singh", StudentClass = "BCA", AttendencePercentage = 65 },
            new StudentAttendenceDTO{Id = 2, StudentName = "Riya Singh", StudentClass = "BBA", AttendencePercentage = 80.20},
            new StudentAttendenceDTO{Id = 3, StudentName = "Suman Singh", StudentClass = "MBA", AttendencePercentage = 75.30},
        };

        [HttpGet("GetAllStudent")]
        public ActionResult<IEnumerable<StudentAttendenceDTO>> GetAllStudent()
        {
            var ltsData = stdLst.ToList();
            return Ok(ltsData);
        }

        [HttpGet("GetStudentById/{id}")]
        public ActionResult<StudentAttendenceDTO> GetStudentById(int id)
        {
           var stdResult = stdLst.Where(x => x.Id == id).FirstOrDefault();
            return Ok(stdResult);
        }
        [HttpPost("AddStudentAttendence")]
        public ActionResult<string> AddStudentAttendence([FromBody] StudentAttendenceDTO obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Somthing wrong.");
            }
            stdLst.Add(obj);
            return Ok("Success");
        }
    }
}
