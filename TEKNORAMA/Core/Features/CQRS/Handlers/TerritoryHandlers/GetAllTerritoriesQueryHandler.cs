using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.TerritoryQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.TerritoryHandlers
{
    public class GetAllTerritoriesQueryHandler : IRequestHandler<GetAllTerritoriesQueryRequest, List<TerritoryListDto>>
    {
        private readonly IRepository<Territory> _repository;
        private readonly IMapper _mapper;

        public GetAllTerritoriesQueryHandler(IRepository<Territory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TerritoryListDto>> Handle(GetAllTerritoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<TerritoryListDto>>(data);
        }
    }
}
