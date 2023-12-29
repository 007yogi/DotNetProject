namespace BasicAuth.BasicAuth
{
    public class ValidateUser
    {
        public static bool Login(string userName, string password)
        {
            if(userName == "admin" && password == "admin@123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
