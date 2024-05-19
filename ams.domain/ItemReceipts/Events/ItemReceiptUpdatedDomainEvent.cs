using ams.domain.Abstractions;

namespace ams.domain.ItemReceipts.Events;

public sealed record ItemReceiptUpdatedDomainEvent(Guid itemReceiptId) : IDomainEvent;
