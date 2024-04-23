using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.domain.Items
{
    public interface IItemRepository
    {
        Task<Item?> GetByIdAsync(Guid id
            , CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Item>> GetByCategoryId(Guid categoryId
            , CancellationToken cancellationToken = default);
    }
}
