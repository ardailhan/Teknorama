using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class GetAllIssuesQueryHandler : IRequestHandler<GetAllIssuesQueryRequest, List<IssueListDto>>
    {
        private readonly IRepository<Issue> _repository;
        private readonly IMapper _mapper;

        public GetAllIssuesQueryHandler(IRepository<Issue> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<IssueListDto>> Handle(GetAllIssuesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<IssueListDto>>(data);
        }
    }
}
