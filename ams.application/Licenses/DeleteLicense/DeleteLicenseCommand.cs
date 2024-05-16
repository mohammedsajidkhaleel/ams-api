using ams.application.Abstractions.Messaging;

namespace ams.application.Licenses.DeleteLicense;
public sealed record DeleteLicenseCommand(
   Guid LicenseId
    ) : ICommand<Guid>;