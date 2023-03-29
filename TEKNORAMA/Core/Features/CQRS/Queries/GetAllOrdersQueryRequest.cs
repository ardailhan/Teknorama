using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries
{
    public class GetAllOrdersQueryRequest : IRequest<List<OrderListDto>>
    {
    }
}
