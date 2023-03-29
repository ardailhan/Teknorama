using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class DeleteMessageCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteMessageCommandRequest(int id)
        {
            Id = id;
        }
    }
}
