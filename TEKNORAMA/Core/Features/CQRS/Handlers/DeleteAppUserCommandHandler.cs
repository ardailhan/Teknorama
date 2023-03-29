using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class DeleteAppUserCommandHandler : IRequestHandler<DeleteAppUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;

        public DeleteAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser deletedAppUser = await _repository.GetByIdAsync(request.Id);
            if (deletedAppUser != null) await _repository.DeleteAsync(deletedAppUser);
            return Unit.Value;
        }
    }
}
