using AutoMapper;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Application.Mappings
{
    public class ShipperProfile : Profile
    {
        public ShipperProfile()
        {
            CreateMap<Shipper, ShipperListDto>().ReverseMap();
        }
    }
}
