namespace TeknoramaUI.Models.BasketItemModel
{
    public class BasketItemCreateRequestModel
    {
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
