using ams.application.Abstractions.Messaging;

namespace ams.application.Employees.GetDepartments;
public sealed record GetDepartmentQuery(
    Guid? departmentId,
    Guid? parentDepartmentId)
    : IQuery<IReadOnlyList<DepartmentResponse>>;
