using ams.domain.Abstractions;

namespace ams.domain.PurchaseOrders.Events;
public sealed record class PurchaseOrderUpdatedDomainEvent(Guid purchaseOrderId)
    : IDomainEvent;
