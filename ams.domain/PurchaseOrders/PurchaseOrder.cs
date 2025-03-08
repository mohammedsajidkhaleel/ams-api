using ams.domain.Abstractions;
using ams.domain.PurchaseOrders.events;
using ams.domain.Shared;

namespace ams.domain.PurchaseOrders;

public sealed class PurchaseOrder
    : Entity
{
    public PONumber PoNumber { get; private set; }
    public DateOnly PurchaseDate { get; private set; }
    public Guid CreatedBy { get; private set; }
    public string CreatedUserName { get; private set; }
    public DateTimeOffset CreationDateTime { get; private set; }
    public ICollection<PurchaseOrderItem> Items { get; set; }
    public string? Description { get; set; }
    private PurchaseOrder()
    {
    }
    public PurchaseOrder(Guid id,
        PONumber poNumber,
        DateOnly purchaseDate,
        Guid createdBy,
        string createdUserName,
        string description) : base(id)
    {
        PoNumber = poNumber;
        PurchaseDate = purchaseDate;
        CreatedBy = createdBy;
        CreatedUserName = createdUserName;
        CreationDateTime = DateTimeOffset.UtcNow;
        Description = description;
    }

    public static PurchaseOrder CreatePurchaseOrder(PONumber poNumber,
        DateOnly purchaseDate,
        Guid createdBy,
        string createdUserName,
        string description,
        List<PurchaseOrderItem> purchaseOrderItems)
    {
        var purchaseOrder = new PurchaseOrder(Guid.NewGuid(), poNumber, purchaseDate, createdBy, createdUserName, description);
        purchaseOrder.Items = purchaseOrderItems;
        purchaseOrder.RaiseDomainEvent(new PurchaseOrderCreatedDomainEvent(purchaseOrder.Id));
        return purchaseOrder;
    }
}
