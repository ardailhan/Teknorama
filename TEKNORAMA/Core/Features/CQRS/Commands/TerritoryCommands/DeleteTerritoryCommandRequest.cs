using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.TerritoryCommands
{
    public class DeleteTerritoryCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteTerritoryCommandRequest(int id)
        {
            Id = id;
        }
    }
}
