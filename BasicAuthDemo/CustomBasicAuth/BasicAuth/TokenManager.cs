namespace BasicAuth.BasicAuth
{
    public class TokenManager : ITokenManager
    {
        public List<Token> listTokens;
        public TokenManager()
        {
            listTokens = new List<Token>();
        }
        public bool Authenticate(string user, string pass)
        {
            if (!string.IsNullOrWhiteSpace(user) &&
                !string.IsNullOrWhiteSpace(pass) &&
                user.ToLower() == "admin" &&
                pass == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Token NewToken()
        {
            var token = new Token
            {
                ExpiryDate = DateTime.Now.AddMinutes(2),
                value = Guid.NewGuid().ToString()
            };
            listTokens.Add(token);
            return token;
        }
        public bool VerifyToken(string token)
        {
            if (listTokens.Any(x => x.value == token && x.ExpiryDate > DateTime.Now))
            {
                return true;
            }
            else
            {
                listTokens.Remove(listTokens.FirstOrDefault(x => x.value == token));
                return false;
            }
        }
    }
}
