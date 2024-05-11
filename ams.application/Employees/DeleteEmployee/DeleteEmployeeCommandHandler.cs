using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.Employees;

namespace ams.application.Employees.DeleteEmployee;
internal sealed class DeleteEmployeeCommandHandler
    : ICommandHandler<DeleteEmployeeCommand, Guid>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        DeleteEmployeeCommand request,
        CancellationToken cancellationToken)
    {
       var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId,cancellationToken);
        if(employee != null) {
            _employeeRepository.Remove(employee);
            await _unitOfWork.SaveChangesAsync();
        }
        return null;
    }
}

