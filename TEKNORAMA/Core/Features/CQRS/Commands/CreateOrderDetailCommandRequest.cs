using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class CreateOrderDetailCommandRequest : IRequest
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
