namespace ams.api.Controllers.PurchaseOrders;

public record PurchaseOrderRequest(
    string PoNumber,
    DateOnly PurchaseDate,
    List<PurchaseOrderItemRequest> Items
    );
public record PurchaseOrderItemRequest(
    Guid ItemId,
    decimal Quantity);
