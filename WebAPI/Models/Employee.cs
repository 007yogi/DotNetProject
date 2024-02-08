using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace WebAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }        
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string DateOfJoining { get; set; }
        [Required]
        public string PhotoFileName { get; set; }
    }
}
