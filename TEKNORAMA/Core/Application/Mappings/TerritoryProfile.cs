using AutoMapper;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Application.Mappings
{
    public class TerritoryProfile : Profile
    {
        public TerritoryProfile()
        {
            CreateMap<Territory, TerritoryListDto>().ReverseMap();
        }
    }
}
