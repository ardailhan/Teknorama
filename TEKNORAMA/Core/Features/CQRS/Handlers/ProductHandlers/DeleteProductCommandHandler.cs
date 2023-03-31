using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.ProductCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.ProductHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public DeleteProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product deletedProduct = await _repository.GetByIdAsync(request.Id);
            if (deletedProduct != null) await _repository.DeleteAsync(deletedProduct);
            return Unit.Value;
        }
    }
}
