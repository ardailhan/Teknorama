using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommandRequest>
    {
        private readonly IRepository<Expense> _repository;

        public CreateExpenseCommandHandler(IRepository<Expense> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateExpenseCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Expense
            {
                Amount = request.Amount,
                Description = request.Description,
                ExpenseType = request.ExpenseType,
                PaymentDate = request.PaymentDate
            });
            return Unit.Value;
        }
    }
}
