using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.UserProfileQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.UserProfileHandlers
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQueryRequest, UserProfileListDto>
    {
        private readonly IRepository<UserProfile> _repository;
        private readonly IMapper _mapper;

        public GetUserProfileQueryHandler(IRepository<UserProfile> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserProfileListDto> Handle(GetUserProfileQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<UserProfileListDto>(data);
        }
    }
}
