using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.CategoryCommands
{
    public class DeleteCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteCategoryCommandRequest(int id)
        {
            Id = id;
        }
    }
}
