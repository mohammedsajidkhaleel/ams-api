using ams.application.Abstractions.Messaging;
using ams.application.Models;

namespace ams.application.Employees.GetEmployeeAccessories;

public sealed record GetEmployeeAccessoriesQuery(Guid employeeId, int pageIndex, int pageSize)
    : IQuery<PaginatedResponse<EmployeeAccessoryResponse>>
{
}
