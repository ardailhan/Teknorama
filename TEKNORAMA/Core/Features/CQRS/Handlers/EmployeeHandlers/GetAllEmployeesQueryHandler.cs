using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.EmployeeQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.EmployeeHandlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQueryRequest, List<EmployeeListDto>>
    {
        private readonly IRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(IRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeListDto>> Handle(GetAllEmployeesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<EmployeeListDto>>(data);
        }
    }
}
