namespace BasicAuth.BasicAuth
{
    public interface ITokenManager
    {
        bool Authenticate(string user, string pass);
        Token NewToken();
        bool VerifyToken(string token);
    }
}