using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.UserProfileQueries
{
    public class GetAllUserProfilesQueryRequest : IRequest<List<UserProfileListDto>>
    {
    }
}
