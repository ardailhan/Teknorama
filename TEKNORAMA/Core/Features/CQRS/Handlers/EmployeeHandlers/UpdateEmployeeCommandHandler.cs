using MediatR;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Core.Domain;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.EmployeeCommands;

namespace TeknoramaBackOffice.Core.Features.CQRS.Handlers.EmployeeHandlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest>
    {
        private readonly IRepository<Employee> _repository;

        public UpdateEmployeeCommandHandler(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            Employee updatedEmployee = await _repository.GetByIdAsync(request.Id);
            if (updatedEmployee != null)
            {
                updatedEmployee.FirstName = request.FirstName;
                updatedEmployee.LastName = request.LastName;
                updatedEmployee.TCNO = request.TCNO;
                updatedEmployee.PhoneNo = request.PhoneNo;
                updatedEmployee.Email = request.Email;
                updatedEmployee.BirthDate = request.BirthDate;
                updatedEmployee.Gender = request.Gender;
                updatedEmployee.MonthlySales = request.MonthlySales;
                updatedEmployee.Salary = request.Salary;
                await _repository.UpdateAsync(updatedEmployee);
            }
            return Unit.Value;
        }
    }
}
