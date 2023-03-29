using MediatR;
using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class CreateMessageCommandRequest : IRequest
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public DateTime MessageDate { get; set; }
        public MessageType MessageType { get; set; }
    }
}
