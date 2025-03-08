namespace ams.api.Controllers.PurchaseOrders;

public record PurchaseOrderRequest(
    string PoNumber,
    DateOnly PurchaseDate,
    string Description,
    List<PurchaseOrderItemRequest> Items
    )
{
}

public record PurchaseOrderItemRequest(
    Guid ItemId,
    decimal Quantity);
