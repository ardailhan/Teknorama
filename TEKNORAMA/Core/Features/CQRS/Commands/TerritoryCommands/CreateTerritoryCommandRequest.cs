using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.TerritoryCommands
{
    public class CreateTerritoryCommandRequest : IRequest
    {
        public string TerritoryDescription { get; set; }
    }
}
