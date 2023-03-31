using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.AppUserQueries
{
    public class GetAllAppUsersQueryRequest : IRequest<List<AppUserListDto>>
    {
    }
}
