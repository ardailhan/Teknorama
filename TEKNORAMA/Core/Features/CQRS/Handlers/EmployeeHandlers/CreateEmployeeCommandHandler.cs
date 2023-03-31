using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.EmployeeCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.EmployeeHandlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest>
    {
        private readonly IRepository<Employee> _repository;

        public CreateEmployeeCommandHandler(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                TCNO = request.TCNO,
                PhoneNo = request.PhoneNo,
                Email = request.Email,
                BirthDate = request.BirthDate,
                Gender = request.Gender,
                MonthlySales = request.MonthlySales,
                Salary = request.Salary,
            });
            return Unit.Value;
        }
    }
}
