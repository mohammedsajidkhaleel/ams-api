namespace ams.application.Employees.GetDepartments;
public sealed class DepartmentResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public Guid? ParentDepartmentId { get; init; }
    public string ParentDepartmentName { get; init; }
}

