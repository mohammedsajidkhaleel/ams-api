using ams.application.Abstractions.Messaging;

namespace ams.application.ItemReceipts.GetItemReceipt;
public sealed record GetItemReceiptQuery(Guid ItemReceiptId)
: IQuery<ItemReceiptResponse>
{
}

