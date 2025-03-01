using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasswordHashing.DataContext;
using PasswordHashing.Models;
using PasswordHashing.Utility;

namespace PasswordHashing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordHashingController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PasswordHashingController(ApplicationContext context)
        {
            this._context = context;
        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO model)
        {
            byte[] passwordHash, passwordSalt;
            PasswordHasher.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);
            User user = new User
            {
                Username = model.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            //For Demo Purpose we are returning the PasswordHash and PasswordSalt
            return Ok(user);
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDTO model)
        {
            var user = await _context.users.FirstOrDefaultAsync(x => x.Username == model.UserName);
            if (user == null || !PasswordHasher.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized("Invalid username or password.");
            }
            // Generate a token or return a success response
            return Ok("User logged in successfully");
        }
    }
}
