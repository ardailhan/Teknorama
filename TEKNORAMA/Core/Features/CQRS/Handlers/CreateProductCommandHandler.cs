﻿using MediatR;
using System.Runtime.CompilerServices;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateProductCommandHandler(IRepository<Product> repository, IWebHostEnvironment webHostEnvironment = null)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
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
                ImagePath = request.ImagePath
            });
            return Unit.Value;
        }
    }
}
