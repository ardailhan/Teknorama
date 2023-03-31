using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.OrderQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.OrderHandlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQueryRequest, List<OrderListDto>>
    {
        private readonly IRepository<Order> _repository;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OrderListDto>> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<OrderListDto>>(data);
        }
    }
}
