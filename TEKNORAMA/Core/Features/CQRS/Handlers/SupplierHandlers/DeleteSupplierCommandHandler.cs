using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.SupplierCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.SupplierHandlers
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommandRequest>
    {
        private readonly IRepository<Supplier> _repository;

        public DeleteSupplierCommandHandler(IRepository<Supplier> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteSupplierCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.Id);
            if (deletedEntity != null) await _repository.DeleteAsync(deletedEntity);
            return Unit.Value;
        }
    }
}
