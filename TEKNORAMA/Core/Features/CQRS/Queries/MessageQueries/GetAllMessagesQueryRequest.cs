using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.MessageQueries
{
    public class GetAllMessagesQueryRequest : IRequest<List<MessageListDto>>
    {
    }
}
