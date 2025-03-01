using Microsoft.AspNetCore.Mvc;
using StudentAdmissionMgmt.Models;

namespace StudentAdmissionMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAdmissionController : ControllerBase
    {
        public static List<StudentAdmissionDTO> stdLst = new List<StudentAdmissionDTO>
        {
            new StudentAdmissionDTO{Id = 1, StudentName = "Jhanvi Singh", StudentClass = "BCA", AdmissionDate = "01/07/2010"},
            new StudentAdmissionDTO{Id = 2, StudentName = "Amit Singh", StudentClass = "MCA", AdmissionDate = "20/08/2013"},
            new StudentAdmissionDTO{Id = 3, StudentName = "Riya Singh", StudentClass = "MBA", AdmissionDate = "10/06/20120"},
        };

        [HttpGet("GetStudentList")]
        public ActionResult<IEnumerable<StudentAdmissionDTO>> GetStudentList()
        {
            var result = stdLst.ToList();
            return Ok(result);
        }
        [HttpGet("GetStudentById/{id}")]
        public ActionResult<StudentAdmissionDTO> GetStudentById(int id)
        {
            var std = stdLst.Where(x => x.Id == id).FirstOrDefault();
            return Ok(std);
        }
        [HttpPost("AdmitNewStudent")]
        public ActionResult<string> AdmitNewStudent(StudentAdmissionDTO std)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            stdLst.Add(std);
            return Ok("New Student Is Admit.");
        }
    }
}
