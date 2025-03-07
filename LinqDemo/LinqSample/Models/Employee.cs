﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LinqSample.Models
{
    [Table("Employee")]
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string DateOfJoining { get;set; }
        public string PhotoFileName { get; set; }
    }
}
