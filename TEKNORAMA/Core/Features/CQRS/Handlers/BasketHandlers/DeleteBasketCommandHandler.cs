using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.BasketCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.BasketHandlers
{
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommandRequest>
    {
        private readonly IRepository<Basket> _repository;

        public DeleteBasketCommandHandler(IRepository<Basket> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteBasketCommandRequest request, CancellationToken cancellationToken)
        {
            Basket deletedBasket = await _repository.GetByIdAsync(request.Id);
            if (deletedBasket != null) await _repository.DeleteAsync(deletedBasket);
            return Unit.Value;
        }
    }
}
