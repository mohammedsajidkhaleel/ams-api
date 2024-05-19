using ams.domain.ItemReceipts;
using Microsoft.EntityFrameworkCore;

namespace ams.infrastructure.Repositories;

internal sealed class ItemReceiptDetailRepository : Repository<ItemReceiptDetail>, IItemReceiptDetailRepository
{
    protected readonly ApplicationDbContext _dbContext;
    public ItemReceiptDetailRepository(ApplicationDbContext dbContext)
  : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ItemReceiptDetail>> GetByItemReceiptIdAsync(Guid itemReceiptId)
    {
        var details = await _dbContext.Set<ItemReceiptDetail>()
                     .Where(b => EF.Property<Guid>(b, "ItemReceiptId") == itemReceiptId).ToListAsync();
        return details;
    }
}
