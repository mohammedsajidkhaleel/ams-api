using ams.application.Abstractions.Messaging;

namespace ams.application.PurchaseOrders.GetPurchaseOrder;

public record GetPurchaseOrderQuery(
    Guid purchaseOrderId)
    : IQuery<PurchaseOrderDetailResponse>;
