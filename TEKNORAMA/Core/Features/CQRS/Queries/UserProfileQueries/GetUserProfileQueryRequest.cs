using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.UserProfileQueries
{
    public class GetUserProfileQueryRequest : IRequest<UserProfileListDto>
    {
        public int Id { get; set; }

        public GetUserProfileQueryRequest(int id)
        {
            Id = id;
        }
    }
}
