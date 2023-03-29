using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class CreateShipperCommandRequest : IRequest
    {
        public string CompanyName { get; set; }
        public string PhoneNo { get; set; }
    }
}
