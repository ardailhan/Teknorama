using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class GetAppRoleQueryHandler : IRequestHandler<GetAppRoleQueryRequest, AppRoleListDto>
    {
        private readonly IRepository<AppRole> _repository;
        private readonly IMapper _mapper;

        public GetAppRoleQueryHandler(IRepository<AppRole> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AppRoleListDto> Handle(GetAppRoleQueryRequest request, CancellationToken cancellationToken)
        {
            AppRole data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<AppRoleListDto>(data);
        }
    }
}
