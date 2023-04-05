using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.BasketQueries
{
    public class GetBasketQueryRequest : IRequest<BasketListDto>
    {
        public int Id { get; set; }

        public GetBasketQueryRequest(int id)
        {
            Id = id;
        }
    }
}
