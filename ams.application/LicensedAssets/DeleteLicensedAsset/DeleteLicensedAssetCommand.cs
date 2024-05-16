using ams.application.Abstractions.Messaging;

namespace ams.application.LicensedAssets.DeleteLicensedAsset;
public sealed record DeleteLicensedAssetCommand(
   Guid LicensedAssetId
    ) : ICommand<Guid>;