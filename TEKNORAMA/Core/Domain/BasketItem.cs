namespace TeknoramaBackOffice.Core.Domain
{
    public class BasketItem : BaseEntity
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        //Navigation Property
        public virtual Basket Basket { get; set; }
        public virtual Product Product { get; set; }
    }
}
