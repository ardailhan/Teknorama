using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class GetShipperQueryHandler : IRequestHandler<GetShipperQueryRequest, ShipperListDto>
    {
        private readonly IRepository<Shipper> _repository;
        private readonly IMapper _mapper;

        public GetShipperQueryHandler(IRepository<Shipper> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ShipperListDto> Handle(GetShipperQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<ShipperListDto>(data);
        }
    }
}
