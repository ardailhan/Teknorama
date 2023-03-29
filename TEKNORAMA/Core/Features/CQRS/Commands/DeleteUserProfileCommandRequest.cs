using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class DeleteUserProfileCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteUserProfileCommandRequest(int id)
        {
            Id = id;
        }
    }
}
