using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries
{
    public class GetAllAppRolesQueryRequest : IRequest<List<AppRoleListDto>>
    {
    }
}
