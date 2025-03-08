namespace ams.application.PurchaseOrders.GetPurchaseOrders;
public sealed class PurchaseOrderResponse
{
    public Guid Id { get; set; }
    public string PoNumber { get; set; }
    public string PurchaseDate { get; set; }
    public string CreationDateTime { get; set; }
    public string CreatedBy { get; set; }
}