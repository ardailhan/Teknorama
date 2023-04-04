using TeknoramaUI.Areas.Administration.Models.CategoryModel;
using TeknoramaUI.Areas.Administration.Models.EmployeeModel;
using TeknoramaUI.Areas.Administration.Models.OrderModel;
using TeknoramaUI.Areas.Administration.Models.ProductModel;

namespace TeknoramaUI.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Amount { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public decimal SubTotal { get { return Price * Amount; } }
        public int ProductId { get; set; }
        public ProductListResponseModel Product { get; set; }
        
    }
}
