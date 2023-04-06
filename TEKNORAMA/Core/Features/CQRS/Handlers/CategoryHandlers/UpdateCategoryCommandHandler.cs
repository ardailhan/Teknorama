using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.CategoryCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedCategory = await _repository.GetByIdAsync(request.Id);
            if (updatedCategory != null)
            {
                updatedCategory.CategoryName = request.CategoryName;
                updatedCategory.Description = request.Description;
                updatedCategory.Status = request.Status;
                updatedCategory.ModifiedDate = DateTime.UtcNow;
                await _repository.UpdateAsync(updatedCategory);
            }
            return Unit.Value;
        }
    }
}
