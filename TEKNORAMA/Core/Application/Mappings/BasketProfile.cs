using AutoMapper;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Application.Mappings
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, BasketItemListDto>().ReverseMap();
        }
    }
}
