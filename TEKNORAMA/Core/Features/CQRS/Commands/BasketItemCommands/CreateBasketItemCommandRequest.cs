using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.BasketItemCommands
{
    public class CreateBasketItemCommandRequest : IRequest
    {
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
