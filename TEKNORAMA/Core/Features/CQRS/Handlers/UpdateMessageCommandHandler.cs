using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommandRequest>
    {
        private readonly IRepository<Message> _repository;

        public UpdateMessageCommandHandler(IRepository<Message> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateMessageCommandRequest request, CancellationToken cancellationToken)
        {
            Message updatedMessage = await _repository.GetByIdAsync(request.Id);
            if (updatedMessage != null)
            {
                updatedMessage.Subject = request.Subject;
                updatedMessage.Description = request.Description;
                updatedMessage.Email = request.Email;
                updatedMessage.MessageDate = request.MessageDate;
                updatedMessage.MessageType = request.MessageType;
                await _repository.UpdateAsync(updatedMessage);
            }
            return Unit.Value;
        }
    }
}
