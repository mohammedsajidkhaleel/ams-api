using ams.domain.ItemReceipts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ams.infrastructure.Configurations;

internal sealed class ItemReceiptItemSerialNumberConfiguration :
    IEntityTypeConfiguration<ItemReceiptItemSerialNumber>
{
    public void Configure(EntityTypeBuilder<ItemReceiptItemSerialNumber> builder)
    {
        builder.ToTable("item_receipt_item_serial_numbers");
        builder.HasKey(item => item.Id);
    }
}
