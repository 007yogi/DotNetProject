using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMapperSample.Models
{
    [Table("Student")]
    public class Student
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Std { get; set; }
        public int? Age { get; set; }
        public string? City { get; set; }
        [NotMapped]
        public string ClassName { get; set; }
        [NotMapped]
        public string Section { get; set; }
        [NotMapped]
        public bool IsAdult { get;set; }
    }
}
