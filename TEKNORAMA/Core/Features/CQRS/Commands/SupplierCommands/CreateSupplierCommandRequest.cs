using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.SupplierCommands
{
    public class CreateSupplierCommandRequest : IRequest
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
