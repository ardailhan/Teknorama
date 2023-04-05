using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.Domain
{
    public class Order
    {

        public int Id { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCity { get; set; }
        public string ShipAddress { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Created;
        public int AppUserId { get; set; }
        public int EmployeeId { get; set; }
        public int ShipperId { get; set; }
        public float? Discount { get; set; }

        public void MakeDiscount()
        {
            TotalPrice -= TotalPrice * 0.15m;
        }

        //Navigation Properties
        public virtual AppUser AppUser { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual Basket Basket { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
