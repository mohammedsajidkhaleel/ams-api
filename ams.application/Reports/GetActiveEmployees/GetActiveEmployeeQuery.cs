using ams.application.Abstractions.Messaging;
using ams.application.Employees.GetEmployees;

namespace ams.application.Reports.ActiveEmployees;

public sealed record GetActiveEmployeeQuery(Guid? ProjectId)
    :IQuery<IReadOnlyList<EmployeeResponse>>;