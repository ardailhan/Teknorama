using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.BasketItemQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.BasketItemHandlers
{
    public class GetBasketItemQueryHandler : IRequestHandler<GetBasketItemQueryRequest, BasketItemListDto>
    {
        private readonly IRepository<BasketItem> _repository;
        private readonly IMapper _mapper;

        public GetBasketItemQueryHandler(IRepository<BasketItem> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BasketItemListDto> Handle(GetBasketItemQueryRequest request, CancellationToken cancellationToken)
        {
            BasketItem data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<BasketItemListDto>(data);
        }
    }
}
