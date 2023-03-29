using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries
{
    public class GetAppUserQueryRequest : IRequest<AppUserListDto>
    {
        public int Id { get; set; }

        public GetAppUserQueryRequest(int id)
        {
            Id = id;
        }
    }
}
