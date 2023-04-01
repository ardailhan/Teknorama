using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.DTOs
{
    public class CategoryListDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DataStatus Status { get; set; } = DataStatus.Inserted;
    }
}
