using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommandRequest>
    {
        private readonly IRepository<Expense> _repository;

        public DeleteExpenseCommandHandler(IRepository<Expense> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteExpenseCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.Id);
            if (deletedEntity != null) await _repository.DeleteAsync(deletedEntity);
            return Unit.Value;
        }
    }
}
