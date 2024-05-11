
using ams.application.Abstractions.Messaging;

namespace ams.application.Assets.DeleteAsset;
public sealed record DeleteAssetCommand(
   Guid AssetId
    ) : ICommand<Guid>;

