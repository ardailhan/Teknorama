using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.UserProfileQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.UserProfileHandlers
{
    public class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfilesQueryRequest, List<UserProfileListDto>>
    {
        private readonly IRepository<UserProfile> _repository;
        private readonly IMapper _mapper;

        public GetAllUserProfilesQueryHandler(IRepository<UserProfile> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserProfileListDto>> Handle(GetAllUserProfilesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<UserProfileListDto>>(data);
        }
    }
}
