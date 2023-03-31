using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.OrderDetailCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.OrderHandlers
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommandRequest>
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                ProductId = request.ProductId,
                OrderId = request.OrderId,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
                TotalPrice = request.TotalPrice
            });
            return Unit.Value;
        }
    }
}
