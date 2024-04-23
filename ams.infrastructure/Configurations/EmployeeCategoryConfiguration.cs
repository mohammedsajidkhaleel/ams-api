using ams.domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ams.infrastructure.Configurations;
internal sealed class EmployeeCategoryConfiguration
    : IEntityTypeConfiguration<EmployeeCategory>
{
    public void Configure(EntityTypeBuilder<EmployeeCategory> builder)
    {
        builder.ToTable("employee_catogories");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(250);
    }
}

