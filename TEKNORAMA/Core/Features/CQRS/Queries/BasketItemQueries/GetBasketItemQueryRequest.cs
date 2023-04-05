using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.BasketItemQueries
{
    public class GetBasketItemQueryRequest : IRequest<BasketItemListDto>
    {
        public int Id { get; set; }

        public GetBasketItemQueryRequest(int id)
        {
            Id = id;
        }
    }
}
