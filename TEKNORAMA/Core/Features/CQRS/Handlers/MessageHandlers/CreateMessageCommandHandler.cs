using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.MessageCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.MessageHandlers
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommandRequest>
    {
        private readonly IRepository<Message> _repository;

        public CreateMessageCommandHandler(IRepository<Message> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateMessageCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Message
            {
                Subject = request.Subject,
                Description = request.Description,
                Email = request.Email,
                MessageDate = request.MessageDate,
                MessageType = request.MessageType,
            });
            return Unit.Value;
        }
    }
}
