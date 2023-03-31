using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.OrderDetailCommands
{
    public class UpdateOrderDetailCommandRequest : IRequest
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
