using System.ComponentModel.DataAnnotations;

namespace AuthServer.Models
{
    public class RefreshTokenDTO
    {
        [Required]
        public string RefreshToken { get; set; }
    }

    public class JwtAuthResponce
    {
        public string AccessToken { get; set; }
        public int ExpireIn { get; set; }
    }
}
