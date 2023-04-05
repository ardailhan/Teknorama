using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.BasketCommands
{
    public class UpdateBasketCommandRequest : IRequest
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
    }
}
