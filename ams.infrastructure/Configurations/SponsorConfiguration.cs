using ams.domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ams.infrastructure.Configurations;
internal sealed class SponsorConfiguration : IEntityTypeConfiguration<Sponsor>
{
    public void Configure(EntityTypeBuilder<Sponsor> builder)
    {
        builder.ToTable("sponsors");
        builder.HasKey(sponsor => sponsor.Id);
        builder.Property(sponsor => sponsor.Name)
            .HasMaxLength(250);
    }
}

