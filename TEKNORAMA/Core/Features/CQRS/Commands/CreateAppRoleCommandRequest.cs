using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class CreateAppRoleCommandRequest : IRequest
    {
        public string Definition { get; set; }
    }
}
