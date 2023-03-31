using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.EmployeeQueries
{
    public class GetAllEmployeesQueryRequest : IRequest<List<EmployeeListDto>>
    {
    }
}
