using ams.application.Abstractions.Messaging;

namespace ams.application.Employees.EditEmployee;
public sealed record EditEmployeeCommand(
    Guid EmployeeId,
    string EmployeeCode,
    string EmployeeName,
    Guid? SponsorId,
    Guid? DepartmentId,
    Guid? EmployeeCategoryId,
    Guid? NationalityId,
    Guid? EmployeePositionId,
    string Mobile,
    string Email,
    string DateOfJoining,
    Guid? ProjectId)
    : ICommand<Guid?>;

