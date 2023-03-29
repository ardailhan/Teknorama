using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries
{
    public class GetAllAppUsersQueryRequest : IRequest<List<AppUserListDto>>
    {
    }
}
