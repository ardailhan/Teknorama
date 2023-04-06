using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.CategoryCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Category
            {
                CategoryName = request.CategoryName,
                Description = request.Description,
                Status = request.Status,
                CreatedDate = DateTime.UtcNow,
            });
            return Unit.Value;
        }
    }
}
