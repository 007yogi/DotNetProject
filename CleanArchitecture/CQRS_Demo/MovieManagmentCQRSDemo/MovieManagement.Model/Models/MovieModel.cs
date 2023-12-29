using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieManagement.Model.Models
{
    public class MovieModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Cost { get; set; }
    }
}
