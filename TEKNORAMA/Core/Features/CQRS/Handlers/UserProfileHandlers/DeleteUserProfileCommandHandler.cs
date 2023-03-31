using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.UserProfileCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.UserProfileHandlers
{
    public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommandRequest>
    {
        private readonly IRepository<UserProfile> _repository;

        public DeleteUserProfileCommandHandler(IRepository<UserProfile> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteUserProfileCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.Id);
            if (deletedEntity != null) await _repository.DeleteAsync(deletedEntity);
            return Unit.Value;
        }
    }
}
