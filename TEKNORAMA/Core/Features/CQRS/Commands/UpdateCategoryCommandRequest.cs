using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class UpdateCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
