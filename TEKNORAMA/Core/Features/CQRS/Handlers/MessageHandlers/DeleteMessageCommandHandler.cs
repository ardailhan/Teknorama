using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.MessageCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.MessageHandlers
{
    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommandRequest>
    {
        private readonly IRepository<Message> _repository;

        public DeleteMessageCommandHandler(IRepository<Message> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteMessageCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.Id);
            if (deletedEntity != null) await _repository.DeleteAsync(deletedEntity);
            return Unit.Value;
        }
    }
}
