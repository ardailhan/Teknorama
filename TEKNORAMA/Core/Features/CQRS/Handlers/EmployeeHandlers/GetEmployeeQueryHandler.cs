using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.EmployeeQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.EmployeeHandlers
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQueryRequest, EmployeeListDto>
    {
        private readonly IRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public GetEmployeeQueryHandler(IRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeListDto> Handle(GetEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<EmployeeListDto>(data);
        }
    }
}
