using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.Employees;

namespace ams.application.Employees.EditEmployee;
public sealed class EditEmployeeCommandHandler
    : ICommandHandler<EditEmployeeCommand, Guid>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EditEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);
        if (employee != null)
        {
            Employee.EditEmployee(employee,
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
        }
        await _unitOfWork.SaveChangesAsync();
        return employee.Id;
    }
}
