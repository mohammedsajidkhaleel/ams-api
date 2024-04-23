using ams.domain.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.infrastructure.Repositories
{
    internal sealed class ItemRepository : Repository<Item>, IItemRepository
    {

        public ItemRepository(ApplicationDbContext dbConext)
            : base(dbConext)
        {

        }
        public Task<IReadOnlyList<Item>> GetByCategoryId(Guid categoryId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
