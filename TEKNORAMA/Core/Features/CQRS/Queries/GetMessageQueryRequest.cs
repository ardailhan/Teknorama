using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries
{
    public class GetMessageQueryRequest : IRequest<MessageListDto>
    {
        public int Id { get; set; }

        public GetMessageQueryRequest(int id)
        {
            Id = id;
        }
    }
}
