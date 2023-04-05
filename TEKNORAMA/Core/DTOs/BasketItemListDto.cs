namespace TeknoramaBackOffice.Core.DTOs
{
    public class BasketItemListDto
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
