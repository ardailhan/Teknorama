using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries
{
    public class GetEmployeeQueryRequest : IRequest<EmployeeListDto>
    {
        public int Id { get; set; }

        public GetEmployeeQueryRequest(int id)
        {
            Id = id;
        }
    }
}
