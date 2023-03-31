using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.AppRoleCommands
{
    public class CreateAppRoleCommandRequest : IRequest
    {
        public string Definition { get; set; }
    }
}
