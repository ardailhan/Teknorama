using MediatR;
using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.OrderCommands
{
    public class UpdateOrderCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCity { get; set; }
        public string ShipAddress { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int EmployeeId { get; set; }
        public int ShipperId { get; set; }
        public float? Discount { get; set; }
    }
}
