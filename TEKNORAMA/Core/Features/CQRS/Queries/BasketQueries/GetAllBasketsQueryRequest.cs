using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.BasketQueries
{
    public class GetAllBasketsQueryRequest : IRequest<List<BasketListDto>>
    {
    }
}
