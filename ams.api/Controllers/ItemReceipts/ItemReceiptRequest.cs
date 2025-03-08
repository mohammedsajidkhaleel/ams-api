namespace ams.api.Controllers.ItemReceipts;
public record ItemReceiptRequest(string poNumber, string? description, List<ItemReceiptDetailItem> itemDetails);
public record ItemReceiptDetailItem(Guid itemId, decimal quantity, string? description, List<string> serialNumbers);
