using ams.application.Abstractions.Messaging;

namespace ams.application.PurchaseOrders.CreatePurchaseOrder;

public sealed record CreatePurchaseOrderCommand(
    string PoNumber,
    DateOnly PurchaseDate,
    Guid CreatedBy,
    string CreatedUserName,
    string Description,
    List<CreatePurchaseOrderItemCommand> Items
    ) : ICommand<Guid>;

public sealed record CreatePurchaseOrderItemCommand(
    Guid ItemId,
    decimal Quantity
    ) : ICommand<Guid>;
