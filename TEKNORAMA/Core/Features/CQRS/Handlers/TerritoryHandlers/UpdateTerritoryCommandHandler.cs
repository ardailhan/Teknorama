using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.TerritoryCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.TerritoryHandlers
{
    public class UpdateTerritoryCommandHandler : IRequestHandler<UpdateTerritoryCommandRequest>
    {
        private readonly IRepository<Territory> _repository;

        public UpdateTerritoryCommandHandler(IRepository<Territory> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateTerritoryCommandRequest request, CancellationToken cancellationToken)
        {
            Territory updatedTerritory = await _repository.GetByIdAsync(request.Id);
            if (updatedTerritory != null)
            {
                updatedTerritory.TerritoryDescription = request.TerritoryDescription;
                await _repository.UpdateAsync(updatedTerritory);
            }
            return Unit.Value;
        }
    }
}
