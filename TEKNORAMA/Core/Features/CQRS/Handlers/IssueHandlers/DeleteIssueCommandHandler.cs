using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.IssueCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.IssueHandlers
{
    public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommandRequest>
    {
        private readonly IRepository<Issue> _repository;

        public DeleteIssueCommandHandler(IRepository<Issue> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteIssueCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.Id);
            if (deletedEntity != null) await _repository.DeleteAsync(deletedEntity);
            return Unit.Value;
        }
    }
}
