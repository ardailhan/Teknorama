using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> _appUserRepository;
        private readonly IRepository<AppRole> _appRoleRepository;

        public CheckUserQueryHandler(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();

            var user = await _appUserRepository.GetByFilterAsync(x=>x.UserName.Equals(request.UserName) && x.Password.Equals(request.Password) && x.ConfirmPassword.Equals(request.ConfirmPassword));

            if(user==null) { dto.Active = false; }
            else 
            { 
                dto.Active = true; 
                dto.UserName = request.UserName;
                dto.Password = request.Password;
                dto.ConfirmPassword = request.ConfirmPassword;
                dto.Id = user.Id;
                AppRole role = await _appRoleRepository.GetByFilterAsync(x => x.Id == user.AppRoleId);
                dto.Role = role.Definition;
            }
            return dto;
        }
    }
}
