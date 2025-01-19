using ams.domain.ItemReceipts;
using ams.domain.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ams.infrastructure.Configurations
{
    internal sealed class ItemReceiptDetailConfiguration :
        IEntityTypeConfiguration<ItemReceiptDetail>
    {
        public void Configure(EntityTypeBuilder<ItemReceiptDetail> builder)
        {
            builder.ToTable("item_receipt_details");
            builder.HasKey(item => item.Id);
            builder.HasOne<Item>()
                .WithMany()
                .HasForeignKey(i => i.ItemId);
        }
    }
}
