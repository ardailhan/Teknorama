using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.ShipperQueries
{
    public class GetAllShippersQueryRequest : IRequest<List<ShipperListDto>>
    {
    }
}
