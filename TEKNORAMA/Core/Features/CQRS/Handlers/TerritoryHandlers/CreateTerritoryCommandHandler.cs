using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.TerritoryCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.TerritoryHandlers
{
    public class CreateTerritoryCommandHandler : IRequestHandler<CreateTerritoryCommandRequest>
    {
        private readonly IRepository<Territory> _repository;

        public CreateTerritoryCommandHandler(IRepository<Territory> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateTerritoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Territory
            {
                TerritoryDescription = request.TerritoryDescription
            });
            return Unit.Value;
        }
    }
}
