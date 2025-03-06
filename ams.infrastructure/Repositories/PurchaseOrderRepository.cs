using ams.domain.PurchaseOrders;

namespace ams.infrastructure.Repositories
{
    internal sealed class PurchaseOrderRepository
        : Repository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
