using ams.domain.Items;
using ams.domain.PurchaseOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ams.infrastructure.Configurations;
internal sealed class PurchaseOrderItemConfiguration
    : IEntityTypeConfiguration<PurchaseOrderItem>
{
    public void Configure(EntityTypeBuilder<PurchaseOrderItem> builder)
    {
        builder.ToTable("purchase_order_items");
        builder.HasKey(e => e.Id);
        builder.HasOne(i => i.PurchaseOrder)
            .WithMany(po => po.Items)
            .HasForeignKey(i => i.PurchaseOrderId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne<Item>()
            .WithMany()
            .HasForeignKey(i => i.ItemId);
        builder.Property(i => i.IsDeleted)
            .HasDefaultValue(false);
    }
}

