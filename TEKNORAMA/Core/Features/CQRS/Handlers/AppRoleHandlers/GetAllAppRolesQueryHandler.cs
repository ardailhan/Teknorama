using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.AppRoleQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.AppRoleHandlers
{
    public class GetAllAppRolesQueryHandler : IRequestHandler<GetAllAppRolesQueryRequest, List<AppRoleListDto>>
    {
        private readonly IRepository<AppRole> _repository;
        private readonly IMapper _mapper;

        public GetAllAppRolesQueryHandler(IRepository<AppRole> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AppRoleListDto>> Handle(GetAllAppRolesQueryRequest request, CancellationToken cancellationToken)
        {
            List<AppRole> data = await _repository.GetAllAsync();
            return _mapper.Map<List<AppRoleListDto>>(data);
        }
    }
}
