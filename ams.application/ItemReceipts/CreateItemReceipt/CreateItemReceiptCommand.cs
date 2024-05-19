using ams.application.Abstractions.Messaging;
using ams.domain.ItemReceipts;

namespace ams.application.ItemReceipts.CreateItemReceipt;
public sealed record CreateItemReceiptCommand(
    string PONumber,
    string Description,
    List<ItemReceiptDetailRequest> ItemDetails
    ) : ICommand<Guid>;

public sealed record ItemReceiptDetailRequest(
    Guid ItemId,
    decimal Quantity,
    string Description,
    List<string> SerialNumbers
    );