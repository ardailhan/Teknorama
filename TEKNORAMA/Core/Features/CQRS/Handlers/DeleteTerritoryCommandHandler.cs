using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class DeleteTerritoryCommandHandler : IRequestHandler<DeleteTerritoryCommandRequest>
    {
        private readonly IRepository<Territory> _repository;

        public DeleteTerritoryCommandHandler(IRepository<Territory> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTerritoryCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity= await _repository.GetByIdAsync(request.Id);
            if (deletedEntity != null) await _repository.DeleteAsync(deletedEntity);
            return Unit.Value;
        }
    }
}
