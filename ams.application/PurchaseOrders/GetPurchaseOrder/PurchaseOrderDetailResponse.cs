namespace ams.application.PurchaseOrders.GetPurchaseOrder;
public sealed class PurchaseOrderDetailResponse
{
    public Guid Id { get; set; }
    public string PoNumber { get; set; }
    public string PurchaseDate { get; set; }
    public string Description { get; set; }
    public List<PurchaseOrderItemDetailResponse> Items { get; set; } = new();
}