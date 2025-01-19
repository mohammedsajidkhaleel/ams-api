using ams.domain.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ams.infrastructure.Configurations;
internal sealed class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("items");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Name)
            .HasMaxLength(250);
        builder.Property(item => item.Description)
            .HasMaxLength(2000);
        builder.HasOne<ItemCategory>()
        .WithMany()
        .HasForeignKey(i => i.ItemCategoryId);
    }
}
