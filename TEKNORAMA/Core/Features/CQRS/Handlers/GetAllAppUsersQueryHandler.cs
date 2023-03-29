using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class GetAllAppUsersQueryHandler : IRequestHandler<GetAllAppUsersQueryRequest, List<AppUserListDto>>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;

        public GetAllAppUsersQueryHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AppUserListDto>> Handle(GetAllAppUsersQueryRequest request, CancellationToken cancellationToken)
        {
            List<AppUser> data = await _repository.GetAllAsync();
            return _mapper.Map<List<AppUserListDto>>(data);
        }
    }
}
