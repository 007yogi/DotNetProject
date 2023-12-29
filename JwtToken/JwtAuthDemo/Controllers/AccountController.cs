using JwtAuthDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IJwtAuthenticationManager _IJwtAuthenticationManager;
        public AccountController(IJwtAuthenticationManager IJwtAuthenticationManager)
        {
            _IJwtAuthenticationManager = IJwtAuthenticationManager;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] AuthenticationRequest obj)
        {
            if(obj == null)
            {
                return BadRequest();
            }
         
            var authResult = _IJwtAuthenticationManager.Authentication(obj.UserName, obj.Password);
            if (authResult == null)
                return Unauthorized();
            else
            return Ok(authResult);
        }
    }
}
