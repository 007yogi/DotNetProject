using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultipleDatabaseAPI.EFContext;
using MultipleDatabaseAPI.Models;

namespace MultipleDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationContext _appContext;
        private readonly LoggingDbContext _logContext;

        public HomeController(ApplicationContext applicationContext, LoggingDbContext loggingContext)
        {
            this._appContext = applicationContext;
            this._logContext = loggingContext;
        }
        [HttpGet("students")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var stdList = await _appContext.Student.ToListAsync();
            return Ok(stdList);
        }
        [HttpGet("logs")]
        public async Task<ActionResult<IEnumerable<LogEntry>>> GetLogs()
        {
            var logs = await _logContext.LogEntry.ToListAsync();
            return Ok(logs);
        }
    }
}
