using System.ComponentModel.DataAnnotations;

namespace TeknoramaUI.Areas.Administration.Models.CategoryModel
{
    public class CategoryCreateRequestModel
    {
        [Required(ErrorMessage = "Category name must not be empty")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Category description must not be empty")]
        public string Description { get; set; }
    }
}
