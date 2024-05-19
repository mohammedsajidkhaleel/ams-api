using ams.domain.ItemReceipts;

namespace ams.infrastructure.Repositories;

internal sealed class ItemReceiptDetailRepository : Repository<ItemReceiptDetail>, IItemReceiptDetailRepository
{
    public ItemReceiptDetailRepository(ApplicationDbContext dbContext)
  : base(dbContext)
    {

    }
}
