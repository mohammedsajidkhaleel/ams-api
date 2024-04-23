using ams.domain.ItemReceipts;

namespace ams.application.ItemReceipts.GetItemReceipts;
public sealed class ItemReceiptsResponse
{
    public Guid Id { get; set; }
    public string ItemReceiptNumber { get; set; }
    public string PONumber { get; set; }
    public DateTimeOffset CreationDateTime { get; set; }
    public string Description { get; set; }
    public ItemReceiptStatus Status { get; set; }
    public string StatusName { get { return Enum.GetName(typeof(ItemReceiptStatus), Status); } }
}
