using MediatR;
using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.ProductCommands
{
    public class CreateProductCommandRequest : IRequest
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public DataStatus Status { get; set; } = DataStatus.Inserted;
    }
}
