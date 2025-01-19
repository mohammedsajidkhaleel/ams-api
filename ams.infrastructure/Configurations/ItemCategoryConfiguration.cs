using ams.domain.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ams.infrastructure.Configurations;
internal sealed class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
{
    public void Configure(EntityTypeBuilder<ItemCategory> builder)
    {
        builder.ToTable("item_categories");
        builder.HasKey(x => x.Id);
        builder.Property(item => item.Name)
           .HasMaxLength(250);
        builder.Property(item => item.Description)
            .HasMaxLength(2000);
        builder.HasOne<ItemCategory>()
        .WithMany()
        .HasForeignKey(i => i.ParentItemCategoryId);
    }
}

