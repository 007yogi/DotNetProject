using AuthServer.Models;
using AuthServer.Services;
using AuthServer.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefreshToken.EFContext;
using RefreshToken.Models;
using System.Security.Cryptography;
using System.Text;

namespace AuthServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;
        private readonly AppDbContext _context;

        public AuthController(IConfiguration configuration, ITokenService tokenService, AppDbContext context)
        {
            this._config = configuration;
            this._tokenService = tokenService;
            this._context = context;
        }

        [HttpPost("UserRegister")]
        public async Task<ActionResult<UserRegister>> UserRegister(RegisterDTO model)
        {
            if (!ModelState.IsValid)    // Validate the incoming model.
            {
                return BadRequest(ModelState);
            }
            // Check if the email already exists.
            var existingUser = await _context.UserRegisters.Where(x => x.EmailId.ToLower() == model.EmailId.ToLower()).FirstOrDefaultAsync();
            if(existingUser is not null)
            {
                return Conflict(new { message = "Email is already registered."});
            }

            // Hash the password
            byte[] passwordHash, passwordSalt;
            PasswordHasher.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);
            UserRegister userReg = new UserRegister
            {
                UserName = model.UserName,
                EmailId = model.EmailId,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            await _context.UserRegisters.AddAsync(userReg);
            await _context.SaveChangesAsync();
            //For Demo Purpose we are returning the PasswordHash and PasswordSalt
            return Ok(userReg);
        }

        [HttpPost("UserLogin")]
        public async Task<ActionResult<string>> UserLogin(LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request body.");
            }
            try
            {
                var user = await _context.UserRegisters.FirstOrDefaultAsync(x => x.EmailId == model.UserName.ToLower());
                if (user == null || !PasswordHasher.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                {
                    return Unauthorized("Invalid username or password.");
                }
                // Issue a new access token for the user.
                var accessToken = await _tokenService.AccessToken(user);
                var refreshToken = GenerateRefreshToken();

                await _tokenService.SaveRefreshToken(user.EmailId, refreshToken);
                return Ok(new {UserId = user.Id, Messagesg = "User logged in successfully", AccessToken = accessToken, RefreshToken = refreshToken });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];  // Prepare a buffer to hold the random bytes.
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);  // Fill the buffer with cryptographically strong random bytes.
                return Convert.ToBase64String(randomNumber);  // Convert the bytes to a Base64 string and return.
            }
        }

        // Helper method to hash tokens before storing them
        private string HashToken(string token)
        {
            //The refresh token is hashed using SHA256 before storing it in the database to prevent token theft from compromising security.
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(token));
            return Convert.ToBase64String(hashedBytes);
        }

        #region
        //Refreshes an access token using a valid refresh token.
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Validate the refresh token request.
            if (request == null || string.IsNullOrWhiteSpace(request.RefreshToken))
            {
                return BadRequest("Refresh token is required.");  // Return bad request if no refresh token is provided.
            }
            try
            {
                // Retrieve the username associated with the provided refresh token.
                var username = await _tokenService.RetrieveUsernameByRefreshToken(request.RefreshToken);
                if (string.IsNullOrEmpty(username))
                {
                    return Unauthorized("Invalid refresh token.");  // Return unauthorized if no username is found (invalid or expired token).
                }
                // Retrieve the user by username.
                var user = await _context.UserRegisters.FirstOrDefaultAsync(u => u.EmailId == username);
                if (user == null)
                {
                    return Unauthorized("Invalid user.");  // Return unauthorized if no user is found.
                }
                // Issue a new access token and refresh token for the user.
                var accessToken = await _tokenService.AccessToken(user);
                var newRefreshToken = GenerateRefreshToken();

                // Save the new refresh token.
                await _tokenService.SaveRefreshToken(user.EmailId, newRefreshToken);
                // Return the new access and refresh tokens.
                return Ok(new { AccessToken = accessToken, RefreshToken = newRefreshToken });
            }
            catch (Exception ex)
            {
                // Handle any exceptions during the refresh process.
                return StatusCode(500, $"Internal server error: {ex.Message}");  // Return a 500 internal server error on exception.
            }
        }

        // Revokes a refresh token to prevent its future use.
        [HttpPost("RevokeToken")]
        public async Task<IActionResult> RevokeToken([FromBody] RefreshTokenDTO request)
        {
            // Validate the revocation request.
            if (request == null || string.IsNullOrWhiteSpace(request.RefreshToken))
            {
                return BadRequest("Refresh token is required.");  // Return bad request if no refresh token is provided.
            }
            try
            {
                // Attempt to revoke the refresh token.
                var result = await _tokenService.RevokeRefreshToken(request.RefreshToken);
                if (!result)
                {
                    return NotFound("Refresh token not found.");  // Return not found if the token does not exist.
                }
                return Ok("Token revoked.");  // Return success message if the token is successfully revoked.
            }
            catch (Exception ex)
            {
                // Handle any exceptions during the revocation process.
                return StatusCode(500, $"Internal server error: {ex.Message}");  // Return a 500 internal server error on exception.
            }
        }
        #endregion

        [HttpGet]
        [Route("GetTokenData")]
        public async Task<IActionResult> GetTokenData()
        {
            List<RefreshTokenModel> lst = new List<RefreshTokenModel>();
            lst = await _tokenService.GetData();
            return Ok(lst);
        }
    }
}
