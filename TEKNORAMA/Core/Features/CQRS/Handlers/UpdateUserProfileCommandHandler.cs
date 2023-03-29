using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommandRequest>
    {
        private readonly IRepository<UserProfile> _repository;

        public UpdateUserProfileCommandHandler(IRepository<UserProfile> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateUserProfileCommandRequest request, CancellationToken cancellationToken)
        {
            UserProfile updatedUserProfile = await _repository.GetByIdAsync(request.Id);
            if (updatedUserProfile != null) 
            {
                updatedUserProfile.FirstName = request.FirstName;
                updatedUserProfile.LastName = request.LastName;
                updatedUserProfile.Address = request.Address;
                updatedUserProfile.TCNO = request.TCNO;
                updatedUserProfile.Age = request.Age;
                updatedUserProfile.ImagePath = request.ImagePath;
                updatedUserProfile.Gender = request.Gender;
                updatedUserProfile.AppUserId = request.AppUserId;
                await _repository.UpdateAsync(updatedUserProfile);
            }
            return Unit.Value;
        }
    }
}
