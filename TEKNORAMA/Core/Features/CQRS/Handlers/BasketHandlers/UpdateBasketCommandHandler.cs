using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.BasketCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.BasketHandlers
{
    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommandRequest>
    {
        private readonly IRepository<Basket> _repository;

        public UpdateBasketCommandHandler(IRepository<Basket> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateBasketCommandRequest request, CancellationToken cancellationToken)
        {
            Basket updatedBasket = await _repository.GetByIdAsync(request.Id);
            if (updatedBasket != null)
            {
                updatedBasket.AppUserId = request.AppUserId;
                await _repository.UpdateAsync(updatedBasket);
            }
            return Unit.Value;
        }
    }
}
