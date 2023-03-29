using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommandRequest>
    {
        private readonly IRepository<Supplier> _repository;

        public UpdateSupplierCommandHandler(IRepository<Supplier> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateSupplierCommandRequest request, CancellationToken cancellationToken)
        {
            Supplier updatedSupplier = await _repository.GetByIdAsync(request.Id);
            if (updatedSupplier != null)
            {
                updatedSupplier.CompanyName = request.CompanyName;
                updatedSupplier.ContactName = request.ContactName;
                updatedSupplier.PhoneNumber = request.PhoneNumber;
                updatedSupplier.Email = request.Email;
                updatedSupplier.Address = request.Address;
                updatedSupplier.City = request.City;
                updatedSupplier.Country = request.Country;
                await _repository.UpdateAsync(updatedSupplier);
            }
            return Unit.Value;
        }
    }
}
