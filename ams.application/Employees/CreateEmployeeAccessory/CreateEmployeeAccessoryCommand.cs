using ams.application.Abstractions.Messaging;

namespace ams.application.LicensedEmployees.CreateEmployeeAccessory;
public sealed record CreateEmployeeAccessoryCommand(
Guid employeeId,
Guid accesoryId,
Guid createdBy)
    : ICommand<Guid>;

