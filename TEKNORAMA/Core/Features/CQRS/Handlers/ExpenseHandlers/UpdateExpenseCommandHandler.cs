using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.ExpenseCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.ExpenseHandler
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommandRequest>
    {
        private readonly IRepository<Expense> _repository;

        public UpdateExpenseCommandHandler(IRepository<Expense> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateExpenseCommandRequest request, CancellationToken cancellationToken)
        {
            Expense updatedExpense = await _repository.GetByIdAsync(request.Id);
            if (updatedExpense != null)
            {
                updatedExpense.Amount = request.Amount;
                updatedExpense.Description = request.Description;
                updatedExpense.ExpenseType = request.ExpenseType;
                updatedExpense.PaymentDate = request.PaymentDate;
                await _repository.UpdateAsync(updatedExpense);
            }
            return Unit.Value;
        }
    }
}
