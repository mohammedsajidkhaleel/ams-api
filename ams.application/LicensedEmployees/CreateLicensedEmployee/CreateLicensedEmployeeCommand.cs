using ams.application.Abstractions.Messaging;

namespace ams.application.LicensedEmployees.CreateLicensedEmployee;
public sealed record CreateLicensedEmployeeCommand(
Guid licenseId,
Guid employeeId,
Guid createdBy)
    : ICommand<Guid>;

