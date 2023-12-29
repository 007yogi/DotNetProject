using JwtAuthDemo.Models;

namespace JwtAuthDemo
{
    public interface IJwtAuthenticationManager
    {
        JwtAuthResponce Authentication(string username, string password);
    }
}
