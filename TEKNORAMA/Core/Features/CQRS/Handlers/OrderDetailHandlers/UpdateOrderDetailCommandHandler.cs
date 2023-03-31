using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.OrderDetailCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.OrderHandlers
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommandRequest>
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            OrderDetail updatedOrderDetail = await _repository.GetByIdAsync(request.Id);
            if (updatedOrderDetail == null)
            {
                updatedOrderDetail.ProductId = request.ProductId;
                updatedOrderDetail.OrderId = request.OrderId;
                updatedOrderDetail.Quantity = request.Quantity;
                updatedOrderDetail.UnitPrice = request.UnitPrice;
                updatedOrderDetail.TotalPrice = request.TotalPrice;
                await _repository.UpdateAsync(updatedOrderDetail);
            }
            return Unit.Value;
        }
    }
}
