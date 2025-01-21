using ams.application.Abstractions.Messaging;

namespace ams.application.Employees.DeleteEmployeeAccessory;

public sealed record DeleteEmployeeAccessoryCommand(
    Guid EmployeeAccessoryId)
    : ICommand<Guid>;
