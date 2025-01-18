using ams.application.Abstractions.Messaging;
using ams.application.Models;

namespace ams.application.Employees.GetEmployees;
public sealed record GetEmployeesQuery(int pageIndex, int pageSize, Guid? projectId, string? searchQuery = null)
: IQuery<PaginatedResponse<EmployeeResponse>>
{
}

