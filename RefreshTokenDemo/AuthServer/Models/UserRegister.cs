namespace AuthServer.Models
{
    public class UserRegister
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
    public class RegisterDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
    }
}
