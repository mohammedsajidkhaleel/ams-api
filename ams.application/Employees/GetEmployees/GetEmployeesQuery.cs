using ams.application.Abstractions.Messaging;

namespace ams.application.Employees.GetEmployees;
public sealed record GetEmployeesQuery(Guid? projectId)
: IQuery<IReadOnlyList<EmployeeResponse>>
{
}

