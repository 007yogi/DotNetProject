using BasicAuth.BasicAuth;
using Microsoft.AspNetCore.Mvc;

namespace BasicAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenManager tokenManager;

        public AuthenticationController(ITokenManager tokenManager)
        {
            this.tokenManager = tokenManager;
        }
        [HttpPost("Authenticate")]
        public IActionResult Authenticate(string user, string pass)
        {
            if (tokenManager.Authenticate(user, pass))
            {
                return Ok(new { Token = tokenManager.NewToken() });
            }
            else
            {
                ModelState.AddModelError("Unauthorized", "you are not authorized");
                return Unauthorized(ModelState);
            }
        }
    }
}
