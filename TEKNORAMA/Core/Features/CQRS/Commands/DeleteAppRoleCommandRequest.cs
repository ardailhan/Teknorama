using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class DeleteAppRoleCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteAppRoleCommandRequest(int id)
        {
            Id = id;
        }
    }
}
