﻿using System.ComponentModel.DataAnnotations;

namespace MovieTracker.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

    }
}