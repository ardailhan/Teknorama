using MediatR;
using TeknoramaBackOffice.Core.Application.Enums;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries
{
    public class GetExpenseQueryRequest : IRequest<ExpenseListDto>
    {
        public int Id { get; set; }
        
        public GetExpenseQueryRequest(int id)
        {
            Id = id;
        }
    }
}
