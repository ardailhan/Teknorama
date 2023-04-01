using MediatR;
using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.ProductCommands
{
    public class UpdateProductCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public DataStatus Status { get; set; } = DataStatus.Updated;
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
