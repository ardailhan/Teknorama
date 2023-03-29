using System.ComponentModel.DataAnnotations;

namespace TeknoramaUI.Areas.Administration.Models
{
    public class CategoryUpdateRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name must not be empty")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Category description must not be empty")]
        public string Description { get; set; }
    }
}
