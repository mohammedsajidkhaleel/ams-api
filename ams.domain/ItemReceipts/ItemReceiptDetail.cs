using ams.domain.Abstractions;
namespace ams.domain.ItemReceipts;
public sealed class ItemReceiptDetail : Entity
{
    public ItemReceiptDetail(Guid id) : base(id)
    {

    }
    private ItemReceiptDetail(Guid id, Guid itemId, decimal quantity, string description) : base(id)
    {
        Id = id;
        ItemId = itemId;
        Quantity = quantity;
        Description = description;
    }
    public Guid ItemId { get; private set; }
    public decimal Quantity { get; private set; }
    public string? Description { get; set; } = string.Empty;
    public static ItemReceiptDetail Create(Guid itemId, decimal quantity, string description)
    {
        var detail = new ItemReceiptDetail(Guid.NewGuid(), itemId, quantity, description);
        return detail;
    }
}

