using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;

        public UpdateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser updatedAppUser = await _repository.GetByIdAsync(request.Id);
            if (updatedAppUser != null) 
            { 
                updatedAppUser.UserName = request.UserName;
                updatedAppUser.Password = request.Password;
                updatedAppUser.ConfirmPassword = request.ConfirmPassword;
                updatedAppUser.Email = request.Email;
                updatedAppUser.Active = request.Active;
                updatedAppUser.AppRoleId = request.AppRoleId;
                await _repository.UpdateAsync(updatedAppUser);
            }
            return Unit.Value;
        }
    }
}
