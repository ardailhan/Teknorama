using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries
{
    public class GetSupplierQueryRequest : IRequest<SupplierListDto>
    {
        public int Id { get; set; }

        public GetSupplierQueryRequest(int id)
        {
            Id = id;
        }
    }
}
