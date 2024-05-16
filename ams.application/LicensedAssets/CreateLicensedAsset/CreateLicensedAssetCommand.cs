using ams.application.Abstractions.Messaging;

namespace ams.application.LicensedAssets.CreateLicensedAsset;
public sealed record CreateLicensedAssetCommand(
Guid licenseId,
Guid assetId,
Guid createdBy)
    : ICommand<Guid>;

