using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommandRequest>
    {
        private readonly IRepository<UserProfile> _repository;

        public CreateUserProfileCommandHandler(IRepository<UserProfile> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateUserProfileCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new UserProfile
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                TCNO = request.TCNO,
                Age = request.Age,
                ImagePath = request.ImagePath,
                Gender = request.Gender,
                AppUserId = request.AppUserId,
            });
            return Unit.Value;
        }
    }
}
