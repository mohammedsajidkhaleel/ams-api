namespace ams.api.Controllers.Employees;
public record EmployeeRequest(
    string Code,
    string Name,
    Guid? SponsorId,
    Guid? DepartmentId,
    Guid? EmployeeCategoryId,
    Guid? NationalityId,
    Guid? EmployeePositionId,
    string Mobile,
    string Email,
    string Doj,
    Guid? ProjectId
    );
