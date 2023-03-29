using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product updatedProduct = await _repository.GetByIdAsync(request.Id);
            if (updatedProduct != null) 
            {
                updatedProduct.ProductName = request.ProductName;
                updatedProduct.UnitPrice = request.UnitPrice;
                updatedProduct.UnitsInStock = request.UnitsInStock;
                updatedProduct.ImagePath = request.ImagePath;
                updatedProduct.CategoryId = request.CategoryId;
                updatedProduct.SupplierId = request.SupplierId;
                await _repository.UpdateAsync(updatedProduct);
            }
            return Unit.Value;
        }
    }
}
