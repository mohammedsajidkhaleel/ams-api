using ams.application.Abstractions.Messaging;

namespace ams.application.Licenses.EditLicense;
public sealed record EditLicenseCommand(
  Guid LicenseId,
  string LicenseName,
  string? Description,
  DateOnly? PurchasedDate,
  DateOnly? ExpirationDate,
  Guid? CreatedBy,
  int TotalLicenses,
  Guid? ProjectId,
  string? PONumber)
    : ICommand<Guid>;

