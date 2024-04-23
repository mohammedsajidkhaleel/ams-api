
using ams.application.Abstractions.Messaging;

namespace ams.application.Assets.CreateAsset;
public sealed record CreateAssetCommand(
    string AssetCode,
    string AssetName,
    string SerialNumber,
    Guid? AssignedTo,
    Guid? ProjectId,
    string AssetDescription,
    Guid? ItemId,
    string PONumber
    ) : ICommand<Guid>;

