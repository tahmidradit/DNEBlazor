using System;
using System.ComponentModel.DataAnnotations;

namespace DNEBlazor.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Created By")]
        public string CreatedByUserId { get; set; }

        [Display(Name = "Updated By")]
        public string UpdatedByUserId { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Display(Name = "Date Updated")]
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
