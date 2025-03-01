using System.ComponentModel.DataAnnotations;

namespace ResourceServer.Models
{
    public class Customer
    {
        public int C_id { get; set; }
        public string C_name { get; set; }
        public string C_address { get; set; }
        public string City { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
