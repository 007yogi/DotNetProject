using AuthServer.Models;
using AuthServer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RefreshToken.EFContext;
using RefreshToken.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RefreshToken.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _config;

        public TokenService(AppDbContext dbContext, IConfiguration configuration)
        {
            this._dbContext = dbContext;
            this._config = configuration;
        }

        public async Task<JwtAuthResponce> AccessToken(UserRegister UserInfo)
        {
            JwtAuthResponce JwtAuth = null;
            var claims = new List<Claim>
            {
                new Claim("Myapp_User_Id", UserInfo.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, UserInfo.UserName),
                new Claim(ClaimTypes.Email, UserInfo.EmailId),
                new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var expiryTime = Convert.ToInt32(_config["Jwt:TokenExpiryInMinutes"]);
            var tokenExpire = DateTime.Now.AddMinutes(expiryTime);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: tokenExpire,
                signingCredentials: credentials
                );

            var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);

            JwtAuth = new JwtAuthResponce
            {
                AccessToken = tokenstring,
                ExpireIn = Convert.ToInt32(tokenExpire.Subtract(DateTime.Now).TotalSeconds)
            };
            return JwtAuth;
        }
        public async Task SaveRefreshToken(string username, string refToken)
        {
            var tokenExpiration = Convert.ToInt32(_config["Jwt:RefreshTokenExpiryInMinutes"]);
            var refreshToken = new RefreshTokenModel
            {
                UserName = username,
                RefreshToken = refToken,
                ExpiryDate = DateTime.Now.AddMinutes(tokenExpiration)  // expiry time for refresh token
            };
            _dbContext.RefreshTokens.Add(refreshToken);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> RetrieveUsernameByRefreshToken(string refreshToken)
        {
            // Asynchronously find a refresh token that matches the provided token and has not yet expired.
            var tokenRecord = await _dbContext.RefreshTokens.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken && x.ExpiryDate > DateTime.Now);
            // Return the username if the token is found and valid, otherwise null.
            return tokenRecord?.UserName;
        }

        // Asynchronously revokes (deletes) a refresh token from the database.
        public async Task<bool> RevokeRefreshToken(string refreshToken)
        {
            // Asynchronously find the refresh token in the database.
            var tokenRecord = await _dbContext.RefreshTokens.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
            // If the token is found, remove it from the DbSet.
            if (tokenRecord != null)
            {
                _dbContext.RefreshTokens.Remove(tokenRecord);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<RefreshTokenModel>> GetData()
        {
            var listdata = await _dbContext.RefreshTokens.ToListAsync();
            return listdata;
        }
    }
}
