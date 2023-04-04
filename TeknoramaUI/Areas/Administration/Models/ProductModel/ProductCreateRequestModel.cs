using System.ComponentModel.DataAnnotations;

namespace TeknoramaUI.Areas.Administration.Models.ProductModel
{
    public class ProductCreateRequestModel
    {
       
        [Required(ErrorMessage = "Product name must not be empty")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product price must not be empty")]
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public IFormFile ImagePath { get; set; }
        public string ImagePathName { get; set; }

        [Required(ErrorMessage = "Product category must not be empty")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Product supplier must not be empty")]
        public int SupplierId { get; set; }
    }
}
