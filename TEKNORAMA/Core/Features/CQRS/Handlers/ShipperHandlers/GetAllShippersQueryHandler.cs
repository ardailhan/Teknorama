using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.ShipperQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.ShipperHandlers
{
    public class GetAllShippersQueryHandler : IRequestHandler<GetAllShippersQueryRequest, List<ShipperListDto>>
    {
        private readonly IRepository<Shipper> _repository;
        private readonly IMapper _mapper;

        public GetAllShippersQueryHandler(IRepository<Shipper> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ShipperListDto>> Handle(GetAllShippersQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<ShipperListDto>>(data);
        }
    }
}
