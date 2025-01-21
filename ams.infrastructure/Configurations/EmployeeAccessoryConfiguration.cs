using ams.domain.Accessories;
using ams.domain.EmployeeAccessories;
using ams.domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ams.infrastructure.Configurations;

internal class EmployeeAccessoryConfiguration
    : IEntityTypeConfiguration<EmployeeAccessory>
{
    public void Configure(EntityTypeBuilder<EmployeeAccessory> builder)
    {
        builder.ToTable("employee_accessories");
        builder.HasKey(x => x.Id);
        builder.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(i => i.EmployeeId);
        builder.HasOne<Accessory>()
            .WithMany()
            .HasForeignKey(i => i.AccessoryId);
    }
}
