using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class DeleteShipperCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteShipperCommandRequest(int id)
        {
            Id = id;
        }
    }
}
