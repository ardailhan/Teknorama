using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.ShipperQueries
{
    public class GetShipperQueryRequest : IRequest<ShipperListDto>
    {
        public int Id { get; set; }

        public GetShipperQueryRequest(int id)
        {
            Id = id;
        }
    }
}
