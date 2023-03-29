using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class CreateCategoryCommandRequest : IRequest
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
