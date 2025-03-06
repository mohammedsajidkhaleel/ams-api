namespace ams.domain.PurchaseOrders;
public interface IPurchaseOrderRepository
{
    void Add(PurchaseOrder purchaseOrder);
    Task<PurchaseOrder?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Remove(PurchaseOrder purchaseOrder);
}

