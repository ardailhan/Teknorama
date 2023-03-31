using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.ShipperCommands
{
    public class UpdateShipperCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNo { get; set; }
    }
}
