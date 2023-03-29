using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class GetAllEmployeeTerritoriesQueryHandler : IRequestHandler<GetAllEmployeeTerritoriesQueryRequest, List<EmployeeTerritoryListDto>>
    {
        private readonly IRepository<EmployeeTerritory> _repository;
        private readonly IMapper _mapper;

        public GetAllEmployeeTerritoriesQueryHandler(IRepository<EmployeeTerritory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeTerritoryListDto>> Handle(GetAllEmployeeTerritoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<EmployeeTerritoryListDto>>(data);
        }
    }
}
