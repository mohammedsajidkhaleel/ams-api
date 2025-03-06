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

    private PurchaseOrder()
    {
    }
    public PurchaseOrder(Guid id,
        PONumber poNumber,
        DateOnly purchaseDate,
        Guid createdBy,
        string createdUserName) : base(id)
    {
        PoNumber = poNumber;
        PurchaseDate = purchaseDate;
        CreatedBy = createdBy;
        CreatedUserName = createdUserName;
        CreationDateTime = DateTimeOffset.UtcNow;
    }

    public static PurchaseOrder CreatePurchaseOrder(PONumber poNumber,
        DateOnly purchaseDate,
        Guid createdBy,
        string createdUserName,
        List<PurchaseOrderItem> purchaseOrderItems)
    {
        var purchaseOrder = new PurchaseOrder(Guid.NewGuid(), poNumber, purchaseDate, createdBy, createdUserName);
        purchaseOrder.Items = purchaseOrderItems;
        purchaseOrder.RaiseDomainEvent(new PurchaseOrderCreatedDomainEvent(purchaseOrder.Id));
        return purchaseOrder;
    }
}
