using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.OrderCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest>
    {
        private readonly IRepository<Order> _repository;

        public CreateOrderCommandHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Order
            {
                ShipCountry = request.ShipCountry,
                ShipCity = request.ShipCity,
                ShipAddress = request.ShipAddress,
                UserName = request.UserName,
                Email = request.Email,
                TotalPrice = request.TotalPrice,
                OrderDate = request.OrderDate,
                OrderStatus = request.OrderStatus,
                EmployeeId = request.EmployeeId,
                ShipperId = request.ShipperId,
                Discount = request.Discount,

            });
            return Unit.Value;
        }
    }
}
