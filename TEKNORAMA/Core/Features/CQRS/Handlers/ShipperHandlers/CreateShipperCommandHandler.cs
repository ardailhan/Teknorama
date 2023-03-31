using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.ShipperCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.ShipperHandlers
{
    public class CreateShipperCommandHandler : IRequestHandler<CreateShipperCommandRequest>
    {
        private readonly IRepository<Shipper> _repository;

        public CreateShipperCommandHandler(IRepository<Shipper> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateShipperCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Shipper
            {
                CompanyName = request.CompanyName,
                PhoneNo = request.PhoneNo
            });
            return Unit.Value;
        }
    }
}
