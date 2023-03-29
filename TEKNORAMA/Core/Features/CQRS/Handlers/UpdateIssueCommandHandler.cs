using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class UpdateIssueCommandHandler : IRequestHandler<UpdateIssueCommandRequest>
    {
        private readonly IRepository<Issue> _repository;

        public UpdateIssueCommandHandler(IRepository<Issue> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateIssueCommandRequest request, CancellationToken cancellationToken)
        {
            Issue updatedIssue = await _repository.GetByIdAsync(request.Id);
            if (updatedIssue != null)
            {
                updatedIssue.AppUserId = request.AppUserId;
                updatedIssue.Subject = request.Subject;
                updatedIssue.Answer = request.Answer;
                updatedIssue.Email = request.Email;
                updatedIssue.IssueStatus = request.IssueStatus;
                updatedIssue.OpenDate = request.OpenDate;
                await _repository.UpdateAsync(updatedIssue);
            } 
            return Unit.Value;
        }
    }
}
