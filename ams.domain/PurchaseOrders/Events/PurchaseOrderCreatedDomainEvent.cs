using ams.domain.Abstractions;

namespace ams.domain.PurchaseOrders.events;
public sealed record class PurchaseOrderCreatedDomainEvent(Guid purchaseOrderId)
    : IDomainEvent;
