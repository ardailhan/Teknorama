using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.BasketItemCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.BasketItemHandlers
{
    public class UpdateBasketItemCommandHandler : IRequestHandler<UpdateBasketItemCommandRequest>
    {
        private readonly IRepository<BasketItem> _repository;

        public UpdateBasketItemCommandHandler(IRepository<BasketItem> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
            BasketItem updatedBasketItem = await _repository.GetByIdAsync(request.Id);
            if (updatedBasketItem != null) 
            { 
                updatedBasketItem.ProductId = request.ProductId;
                updatedBasketItem.Quantity = request.Quantity;
                await _repository.UpdateAsync(updatedBasketItem);
            }
            return Unit.Value;
        }
    }
}
