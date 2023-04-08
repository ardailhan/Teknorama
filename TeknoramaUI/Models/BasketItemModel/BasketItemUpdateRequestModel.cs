namespace TeknoramaUI.Models.BasketItemModel
{
    public class BasketItemUpdateRequestModel
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
