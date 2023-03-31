using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.EmployeeTerritoryQueries
{
    public class GetAllEmployeeTerritoriesQueryRequest : IRequest<List<EmployeeTerritoryListDto>>
    {
    }
}
