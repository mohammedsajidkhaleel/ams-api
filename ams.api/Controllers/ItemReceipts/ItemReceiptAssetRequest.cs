namespace ams.api.Controllers.ItemReceipts;

public record ItemReceiptAssetRequest(
    Guid ItemReceiptSerialId,
    string Code,
    string Name,
    Guid? AssignedTo
    )
{
}
