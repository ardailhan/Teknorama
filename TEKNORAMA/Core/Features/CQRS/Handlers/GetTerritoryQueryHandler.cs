using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class GetTerritoryQueryHandler : IRequestHandler<GetTerritoryQueryRequest, TerritoryListDto>
    {
        private readonly IRepository<Territory> _repository;
        private readonly IMapper _mapper;

        public GetTerritoryQueryHandler(IRepository<Territory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TerritoryListDto> Handle(GetTerritoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<TerritoryListDto>(data);
        }
    }
}
