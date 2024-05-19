using ams.application.Abstractions.Messaging;
using ams.application.ItemReceipts.CreateItemReceipt;
using ams.domain.ItemReceipts;

namespace ams.application.ItemReceipts.EditItemReceipt;
public sealed record EditItemReceiptCommand(
    Guid ItemReceiptId,
    string PONumber,
    string Description,
    List<ItemReceiptDetailRequest> ItemDetails
    ) : ICommand<Guid>;