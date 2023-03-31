using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.SupplierQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.SupplierHandlers
{
    public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQueryRequest, List<SupplierListDto>>
    {
        private readonly IRepository<Supplier> _repository;
        private readonly IMapper _mapper;

        public GetAllSuppliersQueryHandler(IRepository<Supplier> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SupplierListDto>> Handle(GetAllSuppliersQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<SupplierListDto>>(data);
        }
    }
}
