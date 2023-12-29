using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UploadImage.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        [JsonIgnore]
        public string? ProductImage { get; set; }
        [JsonIgnore]
        public string? ImagePath { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
