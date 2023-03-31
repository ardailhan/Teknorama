using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.AppRoleCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.AppRoleHandlers
{
    public class UpdateAppRoleCommandHandler : IRequestHandler<UpdateAppRoleCommandRequest>
    {
        private readonly IRepository<AppRole> _repository;

        public UpdateAppRoleCommandHandler(IRepository<AppRole> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateAppRoleCommandRequest request, CancellationToken cancellationToken)
        {
            AppRole updatedAppRole = await _repository.GetByIdAsync(request.Id);
            if (updatedAppRole != null)
            {
                updatedAppRole.Definition = request.Definition;
                await _repository.UpdateAsync(updatedAppRole);
            }
            return Unit.Value;
        }
    }
}
