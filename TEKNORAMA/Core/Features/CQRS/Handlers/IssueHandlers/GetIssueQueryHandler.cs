using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.IssueQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.IssueHandlers
{
    public class GetIssueQueryHandler : IRequestHandler<GetIssueQueryRequest, IssueListDto>
    {
        private readonly IRepository<Issue> _repository;
        private readonly IMapper _mapper;

        public GetIssueQueryHandler(IRepository<Issue> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IssueListDto> Handle(GetIssueQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<IssueListDto>(data);
        }
    }
}
