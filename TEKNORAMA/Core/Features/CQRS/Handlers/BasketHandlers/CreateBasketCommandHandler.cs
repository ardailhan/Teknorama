using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.BasketCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.BasketHandlers
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommandRequest>
    {
        private readonly IRepository<Basket> _repository;

        public CreateBasketCommandHandler(IRepository<Basket> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Basket
            {
                AppUserId = request.AppUserId
            });
            return Unit.Value;
        }
    }
}
