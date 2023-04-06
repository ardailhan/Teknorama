using MediatR;
using System.Runtime.CompilerServices;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.ProductCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;
        public CreateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
            
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Product
            {
                CategoryId = request.CategoryId,
                SupplierId = request.SupplierId,
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                UnitsInStock = request.UnitsInStock,
                ImagePath = request.ImagePath,
                Status = request.Status,
                CreatedDate = DateTime.UtcNow,
            });
            return Unit.Value;
        }
    }
}
