using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.OrderCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.OrderHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest>
    {
        private readonly IRepository<Order> _repository;

        public UpdateOrderCommandHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Order updatedOrder = await _repository.GetByIdAsync(request.Id);
            if (updatedOrder != null)
            {
                updatedOrder.ShipCountry = request.ShipCountry;
                updatedOrder.ShipCity = request.ShipCity;
                updatedOrder.ShipAddress = request.ShipAddress;
                updatedOrder.UserName = request.UserName;
                updatedOrder.Email = request.Email;
                updatedOrder.TotalPrice = request.TotalPrice;
                updatedOrder.OrderDate = request.OrderDate;
                updatedOrder.OrderStatus = request.OrderStatus;
                updatedOrder.AppUserId = request.AppUserId;
                updatedOrder.EmployeeId = request.EmployeeId;
                updatedOrder.ShipperId = request.ShipperId;
                updatedOrder.Discount = request.Discount;
                await _repository.UpdateAsync(updatedOrder);
            };
            return Unit.Value;
        }
    }
}
