using ams.domain.Employees;
using ams.domain.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ams.infrastructure.Configurations;
internal sealed class EmployeeConfiguration
    : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employees");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(250)
            .HasConversion(name => name.Value, value => new EmployeeName(value));
        builder.Property(e => e.Code)
           .IsRequired()
           .HasMaxLength(100)
           .HasConversion(code => code.Value, value => new EmployeeCode(value));
        builder.Property(e => e.Email)
            .HasConversion(email => email.Value, value => new Email(value));
        builder.Property(e => e.Mobile)
           .HasConversion(mobile => mobile.Value, value => new Mobile(value));
        builder.HasOne<Sponsor>()
            .WithMany()
            .HasForeignKey(i => i.SponsorId);
        builder.HasOne<Department>()
           .WithMany()
           .HasForeignKey(i => i.DepartmentId);
        builder.HasOne<EmployeeCategory>()
        .WithMany()
        .HasForeignKey(i => i.EmployeeCategoryId);
        builder.HasOne<Nationality>()
        .WithMany()
        .HasForeignKey(i => i.NationalityId);
        builder.HasOne<EmployeePosition>()
        .WithMany()
        .HasForeignKey(i => i.EmployeePositionId);
        builder.HasOne<Project>()
        .WithMany()
        .HasForeignKey(i => i.ProjectId);
        builder.Property(i => i.IsDeleted)
            .HasDefaultValue(false);
    }
}

