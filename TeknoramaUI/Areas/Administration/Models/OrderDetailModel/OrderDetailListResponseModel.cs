using TeknoramaUI.Areas.Administration.Models.OrderModel;
using TeknoramaUI.Areas.Administration.Models.ProductModel;

namespace TeknoramaUI.Areas.Administration.Models.OrderDetailModel
{
    public class OrderDetailListResponseModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductListResponseModel Product { get; set; }
        public int OrderId { get; set; }
        public OrderListResponseModel Order { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
