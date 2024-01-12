using JwtTokenApp.DataContext;
using JwtTokenApp.Interface;
using JwtTokenApp.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtTokenApp.Repository
{
    public class IDemoRepo : IDemo
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDBContext _dBContext;

        public IDemoRepo(IConfiguration config, ApplicationDBContext dBContext)
        {
            _config = config;
            _dBContext = dBContext;
        }
        public ResponseModel GetJwtToken(UserModel model)
        {
            ResponseModel responseModel = null;

            var UserInfo = _dBContext.userModels.FirstOrDefault(x => x.loginId == model.loginId && x.password == model.password);

            if (UserInfo is not null)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                    new Claim("userId", UserInfo.loginId.ToString())
                };

                var expiryTime = Convert.ToInt32(_config["Jwt:TokenExpiryInMinutes"]);
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                var tokenExpire = DateTime.Now.AddMinutes(expiryTime);

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims,
                    DateTime.UtcNow,
                    expires: tokenExpire,
                    signingCredentials: credentials
                    );

                var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
                responseModel = new ResponseModel
                {
                    Token = tokenstring,
                    UserName = UserInfo.loginId,
                    ExpireIn = Convert.ToInt32(tokenExpire.Subtract(DateTime.Now).TotalSeconds),
                    EntryDate = DateTime.Now,
                    UserMessage = "Login Success."
                };
            }
            else
            {
                return new ResponseModel { UserMessage = "Login Failed." };
            }
            return (responseModel);
        }
    }
}
