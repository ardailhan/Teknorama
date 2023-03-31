using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.IssueQueries
{
    public class GetIssueQueryRequest : IRequest<IssueListDto>
    {
        public int Id { get; set; }

        public GetIssueQueryRequest(int id)
        {
            Id = id;
        }
    }
}
