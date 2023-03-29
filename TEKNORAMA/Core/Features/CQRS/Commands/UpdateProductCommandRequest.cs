using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class UpdateProductCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
