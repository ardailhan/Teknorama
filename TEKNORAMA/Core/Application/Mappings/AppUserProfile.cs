using AutoMapper;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Application.Mappings
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, AppUserListDto>().ReverseMap();
        }
    }
}
