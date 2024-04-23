using ams.application.Abstractions.Messaging;
using ams.domain.ItemReceipts;

namespace ams.application.ItemReceipts.CreateItemReceipt;
public sealed record CreateItemReceiptCommand(
    string pONumber,
    string description,
    List<ItemReceiptDetail> itemDetails
    ) : ICommand<Guid>;