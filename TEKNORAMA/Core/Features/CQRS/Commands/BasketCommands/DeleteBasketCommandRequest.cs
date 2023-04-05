using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.BasketCommands
{
    public class DeleteBasketCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteBasketCommandRequest(int id)
        {
            Id = id;
        }
    }
}
