using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.BasketItemCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.BasketItemHandlers
{
    public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommandRequest>
    {
        private readonly IRepository<BasketItem> _repository;

        public DeleteBasketItemCommandHandler(IRepository<BasketItem> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
            BasketItem deletedBasketItem = await _repository.GetByIdAsync(request.Id);
            if(deletedBasketItem != null) await _repository.DeleteAsync(deletedBasketItem);
            return Unit.Value;
        }
    }
}
