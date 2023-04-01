using MediatR;
using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DataStatus Status { get; set; } = DataStatus.Updated;
    }
}
