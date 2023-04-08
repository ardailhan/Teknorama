using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.BasketItemCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.BasketItemHandlers
{
    public class CreateBasketItemCommandHandler : IRequestHandler<CreateBasketItemCommandRequest>
    {
        private readonly IRepository<BasketItem> _repository;

        public CreateBasketItemCommandHandler(IRepository<BasketItem> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new BasketItem
            {
                BasketId = request.BasketId,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            });
            return Unit.Value;
        }
    }
}
