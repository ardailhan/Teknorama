using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries
{
    public class GetAllSuppliersQueryRequest : IRequest<List<SupplierListDto>>
    {
    }
}
