using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.EmployeeTerritoryCommands
{
    public class DeleteEmployeeTerritoryCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteEmployeeTerritoryCommandRequest(int id)
        {
            Id = id;
        }
    }
}
