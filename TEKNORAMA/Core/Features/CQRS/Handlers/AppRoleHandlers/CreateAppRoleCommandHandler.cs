using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.AppRoleCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.AppRoleHandlers
{
    public class CreateAppRoleCommandHandler : IRequestHandler<CreateAppRoleCommandRequest>
    {
        private readonly IRepository<AppRole> _repository;

        public CreateAppRoleCommandHandler(IRepository<AppRole> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateAppRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppRole
            {
                Definition = request.Definition,
            });
            return Unit.Value;
        }
    }
}
