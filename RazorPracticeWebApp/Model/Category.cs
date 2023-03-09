using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPracticeWebApp.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Must enter a Display Order")]
        [Display(Name = "Display Order")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }
    }
}

