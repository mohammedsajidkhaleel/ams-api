namespace ams.domain.ItemReceipts;

public interface IItemReceiptDetailRepository
{
    Task<ItemReceiptDetail?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(ItemReceiptDetail itemReceipt);
    void Remove(ItemReceiptDetail itemReceiptDetail);
    Task<List<ItemReceiptDetail>> GetByItemReceiptIdAsync(Guid itemReceiptId);
}
