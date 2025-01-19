using ams.domain.LicensedEmployees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ams.infrastructure.Configurations;
internal sealed class LicensedEmployeeConfiguration
    : IEntityTypeConfiguration<LicensedEmployee>
{
    public void Configure(EntityTypeBuilder<LicensedEmployee> builder)
    {
        builder.ToTable("licensed_employees");
        builder.HasKey(x => x.Id);
    }
}

