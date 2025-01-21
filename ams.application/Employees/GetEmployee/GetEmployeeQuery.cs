using ams.application.Abstractions.Messaging;

namespace ams.application.Employees.GetEmployee;

public sealed record GetEmployeeQuery(Guid employeeId)
    : IQuery<EmployeeDetailResponse>;