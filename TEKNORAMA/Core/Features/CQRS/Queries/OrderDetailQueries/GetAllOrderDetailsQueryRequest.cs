using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetAllOrderDetailsQueryRequest : IRequest<List<OrderDetailListDto>>
    {
    }
}
