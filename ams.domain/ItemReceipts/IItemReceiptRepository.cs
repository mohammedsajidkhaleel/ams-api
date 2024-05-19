using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.domain.ItemReceipts
{
    public interface IItemReceiptRepository
    {
        Task<ItemReceipt?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void Add(ItemReceipt itemReceipt);
        void RemoveAllDetails();
    }
}
