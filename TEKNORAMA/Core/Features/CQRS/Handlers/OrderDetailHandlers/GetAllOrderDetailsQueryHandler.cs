using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.OrderDetailQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.OrderHandlers
{
    public class GetAllOrderDetailsQueryHandler : IRequestHandler<GetAllOrderDetailsQueryRequest, List<OrderDetailListDto>>
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public GetAllOrderDetailsQueryHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OrderDetailListDto>> Handle(GetAllOrderDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<OrderDetailListDto>>(data);
        }
    }
}
