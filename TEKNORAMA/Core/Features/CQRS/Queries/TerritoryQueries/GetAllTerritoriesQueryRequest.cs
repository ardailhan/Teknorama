using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.TerritoryQueries
{
    public class GetAllTerritoriesQueryRequest : IRequest<List<TerritoryListDto>>
    {
    }
}
