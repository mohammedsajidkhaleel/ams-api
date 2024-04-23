using ams.domain.Assets;
using ams.domain.Employees;
using ams.domain.Items;
using ams.domain.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ams.infrastructure.Configurations;
internal sealed class AssetConfiguration
    : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.ToTable("assets");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(250)
            .HasConversion(name => name.Value, value => new AssetName(value));
        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(code => code.Value, value => new AssetCode(value));
        builder.Property(x => x.SerialNumber)
           .IsRequired()
           .HasMaxLength(250)
           .HasConversion(SerialNumber => SerialNumber.Value, value => new SerialNumber(value));
        builder.Property(x => x.Description)
          .IsRequired()
          .HasMaxLength(1000)
          .HasConversion(Description => Description.Value, value => new AssetDescription(value));
        builder.Property(x => x.PONumber)
            .HasMaxLength(50)
            .HasConversion(poNumber => poNumber.Value, value => new PONumber(value));
        builder.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(i => i.AssignedTo);
        builder.HasOne<Project>()
           .WithMany()
           .HasForeignKey(i => i.ProjectId);
        builder.HasOne<Item>()
            .WithMany()
            .HasForeignKey(i => i.ItemId);
        builder.Property(i => i.IsDeleted)
            .HasDefaultValue(false);
    }
}

