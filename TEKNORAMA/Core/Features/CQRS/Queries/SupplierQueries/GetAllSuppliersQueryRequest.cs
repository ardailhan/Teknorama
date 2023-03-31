using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.SupplierQueries
{
    public class GetAllSuppliersQueryRequest : IRequest<List<SupplierListDto>>
    {
    }
}
