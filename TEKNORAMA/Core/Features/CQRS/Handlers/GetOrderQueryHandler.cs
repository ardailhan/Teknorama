using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQueryRequest, OrderListDto>
    {
        private readonly IRepository<Order> _repository;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderListDto> Handle(GetOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<OrderListDto>(data);
        }
    }
}
