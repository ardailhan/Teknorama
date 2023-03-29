using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class UpdateSupplierCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
