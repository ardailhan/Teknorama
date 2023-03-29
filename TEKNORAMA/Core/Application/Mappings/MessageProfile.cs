using AutoMapper;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Application.Mappings
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageListDto>().ReverseMap();
        }
    }
}
