using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.BasketItemQueries
{
    public class GetAllBasketItemsQueryRequest : IRequest<List<BasketItemListDto>>
    {
    }
}
