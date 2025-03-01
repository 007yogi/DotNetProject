using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using WebAPI.DBEntity;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _config;

        public EmployeeController(DataContext context, IMemoryCache memoryCache, IConfiguration config)
        {
            this._context = context;
            this._memoryCache = memoryCache;
            this._config = config;
        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(Employee emp)
        {
            if (emp == null)
            {
                return BadRequest();
            }            
            var userExists = await _context.Employee.FirstOrDefaultAsync(x => x.EmployeeName.ToLower() == emp.EmployeeName.ToLower());
            if (userExists != null)
            {
                ModelState.AddModelError("Custom Error", "User Already Exists!");
                return BadRequest(ModelState);
            }

            await _context.Employee.AddAsync(emp);
            await _context.SaveChangesAsync();
            return Ok($"Employee id: {emp.EmployeeId} added succesfully.");
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var empList = await _context.Employee.FindAsync(id);
            if (empList == null)
            {
                return NotFound("Not Found.");
            }
            return Ok(empList);
        }

        [HttpGet(nameof(GetAllEmployee))]
        public async Task<IActionResult> GetAllEmployee()
        {
            var cacheKey = _config.GetValue<string>("MemoryCache");

            //checks if cache entries exists
            if (!_memoryCache.TryGetValue(cacheKey, out List<Employee> employeeList))
            {
                //calling the server
                employeeList = await _context.Employee.ToListAsync();

                //setting up cache options
                /*var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(10)
                };
                //setting cache entries
                _memoryCache.Set(cacheKey, employeeList, cacheExpiryOptions);*/

                IMemoryCache aa = ServerCacheMemory(cacheKey, employeeList);
            }
            return Ok(employeeList);


            /*var getAll = await _context.Employee.ToListAsync();
            if (getAll != null)
            {
                return Ok(getAll);
            }
            return BadRequest("Data not found.");*/
        }

        private IMemoryCache ServerCacheMemory(string key, List<Employee> emplist )
        {
            //setting up cache options
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(10)
            };
            //setting cache entries
             _memoryCache.Set(key, emplist, cacheExpiryOptions);
            return _memoryCache;
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            if (employee == null || id != employee.EmployeeId)
            {
                return BadRequest();
            }
            var empData = await _context.Employee.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (empData != null)
            {
                empData.EmployeeName = employee.EmployeeName;
                empData.DateOfJoining = employee.DateOfJoining;
                empData.Department = employee.Department;
                empData.PhotoFileName = employee.PhotoFileName;
                var IsUpdated = await _context.SaveChangesAsync();
                if (IsUpdated > 0)
                {
                    return Ok("Record updated for this employee id: " + empData.EmployeeId);
                }
                else
                {
                    return BadRequest("Nothing to update.");
                }

            }
            return NotFound("Record not found.");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmp(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var empData = await _context.Employee.FindAsync(id);
            if (empData == null)
            {
                return NotFound("Record not found.");
            }
            _context.Employee.Remove(empData);
            await _context.SaveChangesAsync();
            return Ok("Deleted Employee id is: " + empData.EmployeeId);

        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdatePartialEmp([FromRoute] int id, JsonPatchDocument<Employee> patchData)
        {
            if (patchData == null || id == 0)
            {
                return BadRequest();
            }
            var EmpData = await _context.Employee.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (EmpData == null)
            {
                return BadRequest();
            }
            patchData.ApplyTo(EmpData, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Employee.Update(EmpData);
            await _context.SaveChangesAsync();
            return Ok(EmpData);
        }
    }
}
