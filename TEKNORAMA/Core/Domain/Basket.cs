namespace TeknoramaBackOffice.Core.Domain
{
    public class Basket : BaseEntity
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }

        //Navigation Property
        public virtual AppUser AppUser { get; set; }
        public virtual List<BasketItem> BasketItems { get; set; }
    }
}
