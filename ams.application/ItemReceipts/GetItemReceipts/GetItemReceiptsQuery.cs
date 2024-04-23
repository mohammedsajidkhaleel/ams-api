using ams.application.Abstractions.Messaging;

namespace ams.application.ItemReceipts.GetItemReceipts;
public sealed record GetItemReceiptsQuery()
: IQuery<IReadOnlyList<ItemReceiptsResponse>>
{
}

