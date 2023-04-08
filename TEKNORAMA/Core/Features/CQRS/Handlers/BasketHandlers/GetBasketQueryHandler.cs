using AutoMapper;
using MediatR;
using System.Runtime.CompilerServices;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.BasketQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.BasketHandlers
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQueryRequest, BasketListDto>
    {
        private readonly IRepository<Basket> _repository;
        private readonly IMapper _mapper;

        public GetBasketQueryHandler(IRepository<Basket> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BasketListDto> Handle(GetBasketQueryRequest request, CancellationToken cancellationToken)
        {
            Basket data = await _repository.GetByFilterAsync(x => x.Id == request.Id );
            return _mapper.Map<BasketListDto>(data);
        }
    }
}
