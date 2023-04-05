using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.BasketItemCommands
{
    public class DeleteBasketItemCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteBasketItemCommandRequest(int id)
        {
            Id = id;
        }
    }
}
