using AutoMapper;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Application.Mappings
{
    public class IssueProfile : Profile
    {
        public IssueProfile()
        {
            CreateMap<Issue, IssueListDto>().ReverseMap();
        }
    }
}
