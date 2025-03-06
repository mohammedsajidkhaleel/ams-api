using ams.domain.Abstractions;

namespace ams.domain.PurchaseOrders;

public sealed class PurchaseOrderItem : Entity
{
    public Guid ItemId { get; private set; }
    public decimal Quantity { get; private set; }
    public Guid PurchaseOrderId { get; private set; }
    public PurchaseOrder PurchaseOrder { get; set; }
    private PurchaseOrderItem()
    {
    }
    public PurchaseOrderItem(Guid id,
        Guid itemId,
        decimal quantity) : base(id)
    {
        ItemId = itemId;
        Quantity = quantity;
    }
    public static PurchaseOrderItem CreatePurchaseOrderItem(Guid itemId, decimal quantity)
    {
        return new PurchaseOrderItem(Guid.NewGuid(), itemId, quantity);
    }
}