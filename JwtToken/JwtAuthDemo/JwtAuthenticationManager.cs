using JwtAuthDemo.Data;
using JwtAuthDemo.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthDemo
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly ApplicationDBContext _context;
        public IConfiguration _configuration;

        public JwtAuthenticationManager(ApplicationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public JwtAuthResponce Authentication(string username, string password)
        {
            var UserInfo = _context.authenticationRequests.FirstOrDefault(x => x.UserName == username && x.Password == password);
            // validate user & password.
            if (UserInfo == null)
            {
                return null;
            }
            var token = AccessToken(UserInfo);

            return token;
        }

        public JwtAuthResponce AccessToken(AuthenticationRequest UserInfo)
        {
            JwtAuthResponce JwtAuth = null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim("UserName", UserInfo.UserName.ToString())
            };

            //var securityToken = jwtSecurityTokenHandler.CreateToken(securityToeknDescriptor);

            var expiryTime = Convert.ToInt32(_configuration["Jwt:TokenExpiryInMinutes"]);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenExpire = DateTime.Now.AddMinutes(expiryTime);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims,
                DateTime.UtcNow,
                expires: tokenExpire,
                signingCredentials: credentials
                );

            var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);

            JwtAuth = new JwtAuthResponce
            {
                Token = tokenstring,
                UserName = UserInfo.UserName,
                ExpireIn = Convert.ToInt32(tokenExpire.Subtract(DateTime.Now).TotalSeconds),
                EntryDate = DateTime.Now
            };
            return JwtAuth;
            //return new { success = true, userName = UserInfo.UserName, token = tokenstring, roleName = UserInfo.UserName };
        }
    }
}
