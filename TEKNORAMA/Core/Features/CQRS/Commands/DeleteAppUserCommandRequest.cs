using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class DeleteAppUserCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteAppUserCommandRequest(int id)
        {
            Id = id;
        }
    }
}
