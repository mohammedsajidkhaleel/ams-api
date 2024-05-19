namespace ams.api.Controllers.ItemReceipts;

public record ItemReceiptAssetRequest(
    Guid ItemReceiptDetailId,
    Guid ItemId,
    string Code,
    string Name,
    Guid? AssignedTo
    )
{
}
