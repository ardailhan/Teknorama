using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.OrderQueries
{
    public class GetAllOrdersQueryRequest : IRequest<List<OrderListDto>>
    {
    }
}
