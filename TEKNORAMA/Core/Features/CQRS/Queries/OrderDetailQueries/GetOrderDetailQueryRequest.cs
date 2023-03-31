using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailQueryRequest : IRequest<OrderDetailListDto>
    {
        public int Id { get; set; }

        public GetOrderDetailQueryRequest(int id)
        {
            Id = id;
        }
    }
}
