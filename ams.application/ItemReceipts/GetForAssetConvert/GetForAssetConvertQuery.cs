using ams.application.Abstractions.Messaging;
using ams.application.ItemReceipts.GetItemReceipt;

namespace ams.application.ItemReceipts.GetForAssetConvert;

public sealed  record GetForAssetConvertQuery(Guid ItemReceiptId) 
    : IQuery<IReadOnlyList<ItemReceiptSerialNumberResponse>>;
