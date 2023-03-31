using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.EmployeeTerritoryCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.EmployeeTerritoryHandlers
{
    public class CreateEmployeeTerritoryCommandHandler : IRequestHandler<CreateEmployeeTerritoryCommandRequest>
    {
        private readonly IRepository<EmployeeTerritory> _repository;

        public CreateEmployeeTerritoryCommandHandler(IRepository<EmployeeTerritory> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateEmployeeTerritoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new EmployeeTerritory
            {
                EmployeeId = request.EmployeeId,
                TerritoryId = request.TerritoryId,
            });
            return Unit.Value;
        }
    }
}
