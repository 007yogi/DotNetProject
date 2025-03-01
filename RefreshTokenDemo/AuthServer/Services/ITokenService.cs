using AuthServer.Models;
using RefreshToken.Models;

namespace AuthServer.Services
{
    public interface ITokenService
    {
        Task<JwtAuthResponce> AccessToken(UserRegister UserInfo);
        Task SaveRefreshToken(string username, string refToken);
        Task<string> RetrieveUsernameByRefreshToken(string refreshToken);
        Task<bool> RevokeRefreshToken(string refreshToken);
        Task<List<RefreshTokenModel>> GetData();
    }
}
