using ams.domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ams.infrastructure.Configurations;
internal sealed class NationalityConfiguration :
    IEntityTypeConfiguration<Nationality>
{
    public void Configure(EntityTypeBuilder<Nationality> builder)
    {
        builder.ToTable("nationalities");
        builder.HasKey(nationality => nationality.Id);
        builder.Property(nationality => nationality.Name)
            .HasMaxLength(250);
    }
}

