using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class DeleteProductCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteProductCommandRequest(int id)
        {
            Id = id;
        }
    }
}
