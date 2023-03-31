using AutoMapper;
using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.ExpenseQueries;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.ExpenseHandler
{
    public class GetAllExpensesQueryHandler : IRequestHandler<GetAllExpensesQueryRequest, List<ExpenseListDto>>
    {
        private readonly IRepository<Expense> _repository;
        private readonly IMapper _mapper;

        public GetAllExpensesQueryHandler(IRepository<Expense> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ExpenseListDto>> Handle(GetAllExpensesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<ExpenseListDto>>(data);
        }
    }
}
