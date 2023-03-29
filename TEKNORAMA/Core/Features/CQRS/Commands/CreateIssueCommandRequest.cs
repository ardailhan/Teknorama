using MediatR;
using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class CreateIssueCommandRequest : IRequest
    {
        public string Subject { get; set; }
        public string Answer { get; set; }
        public IssueStatus IssueStatus { get; set; }
        public DateTime OpenDate { get; set; }
        public string Email { get; set; }
        public int AppUserId { get; set; }
    }
}
