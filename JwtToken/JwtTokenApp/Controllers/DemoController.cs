using JwtTokenApp.DataContext;
using JwtTokenApp.Interface;
using JwtTokenApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtTokenApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDBContext _dBContext;
        private readonly IDemo _demo;

        public DemoController(IConfiguration config, ApplicationDBContext dBContext, IDemo demo)
        {
            _config = config;
            _dBContext = dBContext;
            _demo = demo;
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetTestUnAuthorise")]
        public async Task<IActionResult> GetTestUnAuthorise()
        {
            return Ok("Test UnAuthorise Action Method.");
        }

        [Authorize]
        [HttpGet]
        [Route("GetTestAuthorise")]
        public async Task<IActionResult> GetTestAuthorise()
        {
            return Ok("Test Authorise Action Method.");
        }

        [AllowAnonymous]
        [Route("CheckLogin")]
        [HttpPost]
        public async Task<IActionResult> CheckLogin(UserModel model)
        {
            var result = _demo.GetJwtToken(model);
            return Ok(result);
        }
    }
}
