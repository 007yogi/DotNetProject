using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DBEntity;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public DepartmentController(IConfiguration configuration, DataContext context)
        {
            this._configuration = configuration;
            this._context = context;           
        }
        
        [HttpGet(nameof(GetAllDepartment))]
        public async Task<IActionResult> GetAllDepartment()
        {
            var departmentList = await _context.Department.ToListAsync();

            /*string query = @"select DepartmentId, DepartmentName from dbo.Department";
            DataTable table = new DataTable();
            SqlDataReader myReader;
            string SqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            using (SqlConnection myCon = new SqlConnection(SqlDataSource))
            {
                myCon.Open();
                
                SqlCommand myCommand = new SqlCommand(query, myCon);
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
                myCon.Close();                
            }
            return new JsonResult(table);*/
            return Ok(departmentList);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id )
        {
            var getDep = await _context.Department.FindAsync(id);
            return Ok(getDep);
        }

        [HttpPost(nameof(InsertDepartment))]
        public async Task<IActionResult> InsertDepartment(Department dep) 
        {
            await _context.Department.AddAsync(dep);
            await _context.SaveChangesAsync();

            /*string query = @"insert into dbo.Department values ('"+dep.DepartmentName+@"')";
            DataTable table = new DataTable();
            SqlDataReader myReader;
            string SqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            using (SqlConnection myCon = new SqlConnection(SqlDataSource))
            {
                myCon.Open();
                SqlCommand myCommand = new SqlCommand(query, myCon);
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
                myCon.Close();
            }
            */
            return Ok("Added Successfully.");
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateDepartment([FromRoute] int id, Department dep)
        {
            var depData = await _context.Department.FindAsync(id);
            if (depData != null)
            {
                depData.DepartmentName = dep.DepartmentName;
                await _context.SaveChangesAsync();
                return Ok(depData);                
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteDep([FromRoute] int id)
        {
            var depData = await _context.Department.FindAsync(id);
            if (depData != null)
            {
                _context.Department.Remove(depData);
                await _context.SaveChangesAsync();
                return Ok("Successfully deleted.");
            }
            return NotFound();
        }
    }
}
