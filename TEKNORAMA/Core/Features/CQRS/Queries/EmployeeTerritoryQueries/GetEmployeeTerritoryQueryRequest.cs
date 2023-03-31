using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.EmployeeTerritoryQueries
{
    public class GetEmployeeTerritoryQueryRequest : IRequest<EmployeeTerritoryListDto>
    {
        public int Id { get; set; }

        public GetEmployeeTerritoryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
