using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.BasketQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.BasketHandlers
{
    public class GetAllBasketsQueryHandler : IRequestHandler<GetAllBasketsQueryRequest, List<BasketListDto>>
    {
        private readonly IRepository<Basket> _repository;
        private readonly IMapper _mapper;

        public GetAllBasketsQueryHandler(IRepository<Basket> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BasketListDto>> Handle(GetAllBasketsQueryRequest request, CancellationToken cancellationToken)
        {
            List<Basket> data = await _repository.GetAllAsync();
            return _mapper.Map<List<BasketListDto>>(data);
        }
    }
}
