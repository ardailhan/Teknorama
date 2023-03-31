using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.SupplierQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.SupplierHandlers
{
    public class GetSupplierQueryHandler : IRequestHandler<GetSupplierQueryRequest, SupplierListDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Supplier> _repository;

        public GetSupplierQueryHandler(IMapper mapper, IRepository<Supplier> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<SupplierListDto> Handle(GetSupplierQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<SupplierListDto>(data);
        }
    }
}
