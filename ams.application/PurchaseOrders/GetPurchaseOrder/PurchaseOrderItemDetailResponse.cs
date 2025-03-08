namespace ams.application.PurchaseOrders.GetPurchaseOrder;

public sealed class PurchaseOrderItemDetailResponse
{
    public Guid ItemId { get; set; }
    public string ItemName { get; set; }
    public int Quantity { get; set; }
}