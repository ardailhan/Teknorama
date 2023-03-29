using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class CreateEmployeeTerritoryCommandRequest : IRequest
    {
        public int EmployeeId { get; set; }
        public int TerritoryId { get; set; }
    }
}
