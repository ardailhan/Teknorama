using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.IssueQueries
{
    public class GetAllIssuesQueryRequest : IRequest<List<IssueListDto>>
    {
    }
}
