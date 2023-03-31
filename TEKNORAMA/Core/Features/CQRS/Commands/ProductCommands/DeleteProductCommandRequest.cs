using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.ProductCommands
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
