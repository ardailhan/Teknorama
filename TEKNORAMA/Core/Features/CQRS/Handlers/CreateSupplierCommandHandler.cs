using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommandRequest>
    {
        private readonly IRepository<Supplier> _repository;

        public CreateSupplierCommandHandler(IRepository<Supplier> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateSupplierCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Supplier
            {
                CompanyName = request.CompanyName,
                ContactName = request.ContactName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,
                City = request.City,
                Country = request.Country,
            });
            return Unit.Value;
        }
    }
}
