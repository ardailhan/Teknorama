using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.DTOs
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public DataStatus Status { get; set; } = DataStatus.Inserted;
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
