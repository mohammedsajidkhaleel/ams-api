using ams.domain.ItemReceipts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.infrastructure.Repositories
{
    internal sealed class ItemReceiptRepository : Repository<ItemReceipt>, IItemReceiptRepository
    {
        public ItemReceiptRepository(ApplicationDbContext dbContext)
      : base(dbContext)
        {

        }
    }
}
