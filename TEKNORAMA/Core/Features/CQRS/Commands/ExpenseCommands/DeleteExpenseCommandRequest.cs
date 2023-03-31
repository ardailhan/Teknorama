using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.ExpenseCommands
{
    public class DeleteExpenseCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteExpenseCommandRequest(int id)
        {
            Id = id;
        }
    }
}
