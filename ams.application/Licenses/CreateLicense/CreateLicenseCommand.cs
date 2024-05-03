using ams.application.Abstractions.Messaging;

namespace ams.application.Licenses.CreateLicense;
public sealed record CreateLicenseCommand(
  string LicenseName,
  string? Description,
  DateOnly? PurchasedDate,
  DateOnly? ExpirationDate,
  Guid? CreatedBy,
  int TotalLicenses)
    : ICommand<Guid>;

