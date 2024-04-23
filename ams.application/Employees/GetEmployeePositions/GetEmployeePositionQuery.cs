using ams.application.Abstractions.Messaging;

namespace ams.application.Employees.GetEmployeePositions;
public sealed record GetEmployeePositionQuery()
    : IQuery<IReadOnlyList<EmployeePositionResponse>>;
