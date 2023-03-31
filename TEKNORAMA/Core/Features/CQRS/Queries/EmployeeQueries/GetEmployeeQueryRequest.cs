using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.EmployeeQueries
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
