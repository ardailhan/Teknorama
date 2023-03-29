using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommandRequest>
    {
        private readonly IRepository<Issue> _repository;

        public CreateIssueCommandHandler(IRepository<Issue> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateIssueCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Issue
            {
                AppUserId=request.AppUserId,
                Subject = request.Subject,
                Answer = request.Answer,
                IssueStatus = request.IssueStatus,
                OpenDate = request.OpenDate,
                Email = request.Email
            });
            return Unit.Value;
        }
    }
}
