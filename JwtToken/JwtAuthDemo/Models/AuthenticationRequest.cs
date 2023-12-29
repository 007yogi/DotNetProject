using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtAuthDemo.Models
{
    [Table("UserInfo")]
    [Serializable]
    public class AuthenticationRequest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set;}
        [Required]
        public string Password { get; set;}
        [NotMapped]
        public string? Email { get; set;}
    }
}
