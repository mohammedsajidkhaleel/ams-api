using ams.domain.Abstractions;
namespace ams.domain.ItemReceipts;
public class ItemReceiptDetail : Entity
{
    public Guid ItemId { get; private set; }
    public decimal Quantity { get; private set; }
    public string? Description { get; set; } = string.Empty;
    public ItemReceipt ItemReceipt { get; set; }
    public virtual List<ItemReceiptItemSerialNumber> SerialNumbers { get; private set; } = new();
    public ItemReceiptDetail(Guid id) : base(id)
    {

    }
    private ItemReceiptDetail(Guid id, Guid itemId, decimal quantity, string description,
        List<ItemReceiptItemSerialNumber> serialNumbers) : base(id)
    {
        Id = id;
        ItemId = itemId;
        Quantity = quantity;
        Description = description;
       // SerialNumbers = serialNumbers;
    }
    public static ItemReceiptDetail Create(Guid itemId, decimal quantity, string description,List<ItemReceiptItemSerialNumber> serialNumbers)
    {
        var detail = new ItemReceiptDetail(Guid.NewGuid(), itemId, quantity, description,serialNumbers);
        return detail;
    }
}

