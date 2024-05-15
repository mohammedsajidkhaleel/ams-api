using ams.domain.Licenses;
using ams.domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ams.infrastructure.Configurations;
internal sealed class LicenseConfiguration
    : IEntityTypeConfiguration<License>
{
    public void Configure(EntityTypeBuilder<License> builder)
    {
        builder.ToTable("licenses");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(250)
            .HasConversion(name => name.Value, value => new LicenseName(value));
        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(description => description.Value, value => new LicenseDescription(value));
        builder.Property(x => x.TotalLicenses)
            .HasDefaultValue(0);
        builder.Property(i => i.IsDeleted)
            .HasDefaultValue(false);
        builder.Property(x => x.PONumber)
           .HasMaxLength(50)
           .HasConversion(poNumber => poNumber.Value, value => new PONumber(value));
    }
}

