using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class DeleteEmployeeTerritoryCommandHandler : IRequestHandler<DeleteEmployeeTerritoryCommandRequest>
    {
        private readonly IRepository<EmployeeTerritory> _repository;

        public DeleteEmployeeTerritoryCommandHandler(IRepository<EmployeeTerritory> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteEmployeeTerritoryCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.Id);
            if (deletedEntity != null) await _repository.DeleteAsync(deletedEntity);
            return Unit.Value;
        }
    }
}
