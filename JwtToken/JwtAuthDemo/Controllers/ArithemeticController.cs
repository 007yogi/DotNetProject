using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class ArithemeticController : ControllerBase
    {
        [AllowAnonymous]
        [Route("GetUnAuthorise")]
        [HttpGet]
        public async Task<IActionResult> GetUnAuthorise()
        {
            return Ok("UnAuthorise Action Method.");
        }
        [Authorize]
        [HttpGet]
        [Route("GetTestAuthorize")]
        public async Task<IActionResult> GetTestAuthorize(int a, int b)
        {
            var ss = HttpContext.User.Claims;
            return Ok("Hello world" + ", Sum is =>"+(a+b));
        }
    }
}
