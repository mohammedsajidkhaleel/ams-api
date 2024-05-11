using ams.application.Abstractions.Messaging;

namespace ams.application.Employees.DeleteEmployee;
public sealed record DeleteEmployeeCommand(
   Guid EmployeeId
    ) : ICommand<Guid>;