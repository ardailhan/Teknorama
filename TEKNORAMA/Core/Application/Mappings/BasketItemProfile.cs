using AutoMapper;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Application.Mappings
{
    public class BasketItemProfile : Profile
    {
        public BasketItemProfile()
        {
            CreateMap<BasketItem, BasketItemListDto>().ReverseMap();
        }
    }
}
