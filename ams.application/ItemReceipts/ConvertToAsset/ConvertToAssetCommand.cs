using ams.application.Abstractions.Messaging;

namespace ams.application.ItemReceipts.ConvertToAsset;

public sealed record ConvertToAssetCommand() : 
    IQuery<List<Guid>>;