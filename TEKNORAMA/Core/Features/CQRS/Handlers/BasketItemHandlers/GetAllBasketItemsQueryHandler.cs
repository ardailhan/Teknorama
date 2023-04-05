using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.BasketItemQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.BasketItemHandlers
{
    public class GetAllBasketItemsQueryHandler : IRequestHandler<GetAllBasketItemsQueryRequest, List<BasketItemListDto>>
    {
        private readonly IRepository<BasketItem> _repository;
        private readonly IMapper _mapper;

        public GetAllBasketItemsQueryHandler(IRepository<BasketItem> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BasketItemListDto>> Handle(GetAllBasketItemsQueryRequest request, CancellationToken cancellationToken)
        {
            List<BasketItem> data = await _repository.GetAllAsync();
            return _mapper.Map<List<BasketItemListDto>>(data);
        }
    }
}
