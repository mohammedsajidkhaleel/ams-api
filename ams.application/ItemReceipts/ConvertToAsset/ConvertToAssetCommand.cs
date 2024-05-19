using ams.application.Abstractions.Messaging;

namespace ams.application.ItemReceipts.ConvertToAsset;

public sealed record ConvertToAssetCommand(Guid ItemReceiptId,List<AssetCreationRequest> Assets) :
    ICommand<bool>
{
}

public sealed record AssetCreationRequest(Guid ItemReceiptSerialNumberId,
    Guid ItemId,
    string AssetCode,
    string AssetName,
    Guid? AssignedTo);