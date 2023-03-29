using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries
{
    public class GetAllEmployeeTerritoriesQueryRequest : IRequest<List<EmployeeTerritoryListDto>>
    {
    }
}
