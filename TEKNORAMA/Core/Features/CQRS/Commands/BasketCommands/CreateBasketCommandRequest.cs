using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.BasketCommands
{
    public class CreateBasketCommandRequest : IRequest
    {
        public int AppUserId { get; set; }
    }
}
