using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.Employees;
using ams.domain.ItemReceipts;

namespace ams.application.Employees.CreateEmployee;
public sealed class CreateEmployeeCommandHandler
    : ICommandHandler<CreateEmployeeCommand, Guid>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = Employee.CreateEmployee(
            new EmployeeCode(request.EmployeeCode),
            new EmployeeName(request.EmployeeName),
            request.SponsorId,
            request.DepartmentId,
            request.EmployeeCategoryId,
            request.NationalityId,
            request.EmployeePositionId,
            new Mobile(request.Mobile),
            new Email(request.Email),
            DateOnly.Parse(request.DateOfJoining),
            request.ProjectId,
            EmployeeStatus.Active
            );
        _employeeRepository.Add(employee);
        await _unitOfWork.SaveChangesAsync();
        return employee.Id;
    }
}
