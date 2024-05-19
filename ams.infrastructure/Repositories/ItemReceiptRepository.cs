using ams.domain.ItemReceipts;

namespace ams.infrastructure.Repositories;

internal sealed class ItemReceiptRepository : Repository<ItemReceipt>, IItemReceiptRepository
{

    public ItemReceiptRepository(ApplicationDbContext dbContext)
  : base(dbContext)
    {

    }

    public void RemoveAllDetails()
    {
        var details = _dbContext
                         .Set<ItemReceipt>()
                         .Select(i => i.Details);
        
    }
}
