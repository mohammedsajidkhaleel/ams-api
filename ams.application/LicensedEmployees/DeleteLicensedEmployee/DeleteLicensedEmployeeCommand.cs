using ams.application.Abstractions.Messaging;

namespace ams.application.LicensedEmployees.DeleteLicensedEmployee;
public sealed record DeleteLicensedEmployeeCommand(
   Guid LicensedEmployeeId
    ) : ICommand<Guid>;