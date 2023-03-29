using AutoMapper;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Application.Mappings
{
    public class UserProfileProfile : Profile
    {
        public UserProfileProfile()
        {
            CreateMap<UserProfile, UserProfileListDto>().ReverseMap();
        }
    }
}
