using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BasicAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [Authorize(Roles ="Admin")]
        [HttpGet("Auth", Name = "AuthStatus")]
        public ActionResult AuthStatus()
        {        
            var username = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            
            var response = new
            {
                Message = "Auth is Up!",
                ServerTime = DateTime.Now,
                UserName = username
            };
            return Ok(response);
        }
    }
}
