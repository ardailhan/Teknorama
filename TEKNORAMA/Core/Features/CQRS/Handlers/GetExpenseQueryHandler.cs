using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers
{
    public class GetExpenseQueryHandler : IRequestHandler<GetExpenseQueryRequest, ExpenseListDto>
    {
        private readonly IRepository<Expense> _repository;
        private readonly IMapper _mapper;

        public GetExpenseQueryHandler(IRepository<Expense> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ExpenseListDto> Handle(GetExpenseQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<ExpenseListDto>(data);
        }
    }
}
