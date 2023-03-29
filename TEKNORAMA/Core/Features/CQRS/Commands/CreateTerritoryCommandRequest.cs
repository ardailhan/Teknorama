using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class CreateTerritoryCommandRequest : IRequest
    {
        public string TerritoryDescription { get; set; }
    }
}
