﻿using System.ComponentModel.DataAnnotations.Schema;

namespace JwtAuthDemo.Models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
