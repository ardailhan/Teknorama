using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.ShipperCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.ShipperHandlers
{
    public class DeleteShipperCommandHandler : IRequestHandler<DeleteShipperCommandRequest>
    {
        private readonly IRepository<Shipper> _repository;

        public DeleteShipperCommandHandler(IRepository<Shipper> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteShipperCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.Id);
            if (deletedEntity != null) await _repository.DeleteAsync(deletedEntity);
            return Unit.Value;
        }
    }
}
