using AuthServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RefreshToken.Models;

namespace AuthServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;
        public HomeController(IConfiguration configuration, ITokenService tokenService)
        {
            this._config = configuration;
            this._tokenService = tokenService;
        }
    }
}
