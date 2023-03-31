using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.ExpenseQueries
{
    public class GetAllExpensesQueryRequest : IRequest<List<ExpenseListDto>>
    {
    }
}
