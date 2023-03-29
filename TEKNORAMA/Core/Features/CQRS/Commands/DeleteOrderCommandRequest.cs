using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class DeleteOrderCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteOrderCommandRequest(int id)
        {
            Id = id;
        }
    }
}
