using ams.domain.Employees;
using ams.domain.Projects;
using ams.domain.PurchaseOrders;
using ams.domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ams.infrastructure.Configurations;
internal sealed class PurchaseOrderConfiguration
    : IEntityTypeConfiguration<PurchaseOrder>
{
    public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
    {
        builder.ToTable("purchase_orders");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.PoNumber)
            .IsRequired()
            .HasMaxLength(250)
            .HasConversion(name => name.Value, value => new PONumber(value));
        builder.Property(i => i.IsDeleted)
            .HasDefaultValue(false);
    }
}

