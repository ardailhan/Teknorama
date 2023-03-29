using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQueryRequest, OrderDetailListDto>
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderDetailListDto> Handle(GetOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<OrderDetailListDto>(data);
        }
    }
}
