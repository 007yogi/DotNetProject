using JwtTokenApp.Models;

namespace JwtTokenApp.Interface
{
    public interface IDemo
    {
        ResponseModel GetJwtToken(UserModel model);
    }
}
