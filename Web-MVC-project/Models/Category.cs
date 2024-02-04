using System.ComponentModel.DataAnnotations;

namespace Web_MVC_project.Models
{
    public class Category
    {
        [Key]
        public int categoryID { get; set; }

        [Required]
        public string categoryName { get; set; }

        public int displayOrder { get; set; }
    }
}
