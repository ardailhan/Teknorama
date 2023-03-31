using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.AppRoleCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.AppRoleHandlers
{
    public class DeleteAppRoleCommandHandler : IRequestHandler<DeleteAppRoleCommandRequest>
    {
        private readonly IRepository<AppRole> _repository;

        public DeleteAppRoleCommandHandler(IRepository<AppRole> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAppRoleCommandRequest request, CancellationToken cancellationToken)
        {
            AppRole deletedAppRole = await _repository.GetByIdAsync(request.Id);
            if (deletedAppRole != null) await _repository.DeleteAsync(deletedAppRole);
            return Unit.Value;
        }
    }
}
