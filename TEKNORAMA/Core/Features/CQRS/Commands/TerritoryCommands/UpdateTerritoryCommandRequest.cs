using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.TerritoryCommands
{
    public class UpdateTerritoryCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string TerritoryDescription { get; set; }
    }
}
