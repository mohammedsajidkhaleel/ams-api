using ams.domain.Abstractions;

namespace ams.domain.ItemReceipts;

public sealed class ItemReceiptItemSerialNumber : Entity
{
    public string SerialNumber { get; set; }
    public ItemReceiptDetail ItemReceiptDetail { get; set; }
    public ItemReceiptItemSerialNumber()
    {
        Id = Guid.NewGuid();
    }
    public ItemReceiptItemSerialNumber(string serialNumber) : this()
    {
        SerialNumber = serialNumber;
    }
}
