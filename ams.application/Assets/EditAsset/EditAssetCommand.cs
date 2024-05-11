
using ams.application.Abstractions.Messaging;

namespace ams.application.Assets.EditAsset;
public sealed record EditAssetCommand(
    Guid AssetId,
    string AssetCode,
    string AssetName,
    string SerialNumber,
    Guid? AssignedTo,
    Guid? ProjectId,
    string AssetDescription,
    Guid? ItemId,
    string PONumber
    ) : ICommand<Guid>;

