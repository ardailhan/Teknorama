using TeknoramaUI.Areas.Administration.Models.OrderModel;
using TeknoramaUI.Areas.Administration.Models.ProductModel;
using TeknoramaUI.Models.BasketModel;

namespace TeknoramaUI.Models.BasketItemModel
{
    public class BasketItemListResponseModel
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int Quantity { get; set; }
        public BasketListResponseModel Basket { get; set; }
        public int ProductId { get; set; }
        public ProductListResponseModel Product { get; set; }
    }
}
