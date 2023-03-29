using AutoMapper;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Application.Mappings
{
    public class EmployeeTerritoryProfile : Profile
    {
        public EmployeeTerritoryProfile()
        {
            CreateMap<EmployeeTerritory, EmployeeTerritoryListDto>().ReverseMap();
        }
    }
}
