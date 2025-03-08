using ams.application.Abstractions.Messaging;

namespace ams.application.PurchaseOrders.DeletePurchaseOrder;
public sealed record DeletePurchaseOrderCommand(
   Guid PurchaseOrderId
    ) : ICommand<Guid>;