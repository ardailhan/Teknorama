using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class UpdateTerritoryCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string TerritoryDescription { get; set; }
    }
}
