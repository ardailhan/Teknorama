using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class DeleteOrderDetailCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteOrderDetailCommandRequest(int id)
        {
            Id = id;
        }
    }
}
