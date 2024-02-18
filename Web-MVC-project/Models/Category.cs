using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web_MVC_project.Models
{
    public class Category
    {
        [Key]
        public int categoryID { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string categoryName { get; set; }
        
        [Range(1, 100, ErrorMessage = "Display Order for category must be between 1-100")]
        [DisplayName("Display Order")]
        public int displayOrder { get; set; }
    }
}
