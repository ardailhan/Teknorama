using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaUI.Areas.Administration.Models
{
    public class OrderListResponseModel
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
        public float? Discount { get; set; }
        public int AppUserId { get; set; }
        public AppUserListResponseModel AppUser { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeListResponseModel Employee { get; set; }
        public int ShipperId { get; set; }
        public ShipperListResponseModel Shipper { get; set; }
    }
}
