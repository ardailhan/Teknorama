using AutoMapper;
using MediatR;
using System.Runtime.CompilerServices;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.AppUserQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.AppUserHandlers
{
    public class GetAppUserQueryHandler : IRequestHandler<GetAppUserQueryRequest, AppUserListDto>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;

        public GetAppUserQueryHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AppUserListDto> Handle(GetAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            AppUser data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<AppUserListDto>(data);
        }
    }
}
