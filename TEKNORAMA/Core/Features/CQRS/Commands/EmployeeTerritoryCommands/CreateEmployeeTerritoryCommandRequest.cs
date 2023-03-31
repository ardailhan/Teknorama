using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.EmployeeTerritoryCommands
{
    public class CreateEmployeeTerritoryCommandRequest : IRequest
    {
        public int EmployeeId { get; set; }
        public int TerritoryId { get; set; }
    }
}
