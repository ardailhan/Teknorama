using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.OrderCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.OrderHandlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest>
    {
        private readonly IRepository<Order> _repository;

        public DeleteOrderCommandHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.Id);
            if (deletedEntity != null) await _repository.DeleteAsync(deletedEntity);
            return Unit.Value;
        }
    }
}
