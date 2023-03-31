using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.ShipperCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.ShipperHandlers
{
    public class UpdateShipperCommandHandler : IRequestHandler<UpdateShipperCommandRequest>
    {
        private readonly IRepository<Shipper> _repository;

        public UpdateShipperCommandHandler(IRepository<Shipper> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateShipperCommandRequest request, CancellationToken cancellationToken)
        {
            Shipper updatedShipper = await _repository.GetByIdAsync(request.Id);
            if (updatedShipper != null)
            {
                updatedShipper.CompanyName = request.CompanyName;
                updatedShipper.PhoneNo = request.PhoneNo;
                await _repository.UpdateAsync(updatedShipper);
            }
            return Unit.Value;
        }
    }
}
