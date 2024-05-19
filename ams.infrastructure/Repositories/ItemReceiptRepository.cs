using ams.domain.ItemReceipts;

namespace ams.infrastructure.Repositories;

internal sealed class ItemReceiptRepository : Repository<ItemReceipt>, IItemReceiptRepository
{
    public ItemReceiptRepository(ApplicationDbContext dbContext)
  : base(dbContext)
    {

    }
}
