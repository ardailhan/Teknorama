using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;

        public CreateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {
                UserName = request.UserName,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                Email = request.Email,
                Active = request.Active,
                AppRoleId = request.AppRoleId
            });
            return Unit.Value;
        }
    }
}
