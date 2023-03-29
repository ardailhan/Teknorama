using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryListDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _repository;

        public GetCategoryQueryHandler(IMapper mapper, IRepository<Category> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CategoryListDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<CategoryListDto>(await _repository.GetByFilterAsync(x=>x.Id == request.Id));
        }
    }
}
