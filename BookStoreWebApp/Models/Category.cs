﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display order must be between 1 and 100")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    }
}

