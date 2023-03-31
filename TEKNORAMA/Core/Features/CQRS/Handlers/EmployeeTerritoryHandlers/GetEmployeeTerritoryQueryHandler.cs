using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.EmployeeTerritoryQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.EmployeeTerritoryHandlers
{
    public class GetEmployeeTerritoryQueryHandler : IRequestHandler<GetEmployeeTerritoryQueryRequest, EmployeeTerritoryListDto>
    {
        private readonly IRepository<EmployeeTerritory> _repository;
        private readonly IMapper _mapper;

        public GetEmployeeTerritoryQueryHandler(IRepository<EmployeeTerritory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeTerritoryListDto> Handle(GetEmployeeTerritoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<EmployeeTerritoryListDto>(data);
        }
    }
}
