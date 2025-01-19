using ams.domain.Employees;
using ams.domain.Items;
using ams.domain.Projects;
using ams.domain.Shared;
using ams.domain.Sims;
using ams.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ams.infrastructure.Configurations;
internal sealed class SimConfiguration
    : IEntityTypeConfiguration<Sim>
{
    public void Configure(EntityTypeBuilder<Sim> builder)
    {
        builder.ToTable("sims");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ServiceAccount)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(serviceaccount => serviceaccount.Value, value => new ServiceAccount(value));
        builder.Property(x => x.ServiceNumber)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(servicenumber => servicenumber.Value, value => new ServiceNumber(value));
        builder.Property(x => x.SimCardNumber)
           .IsRequired()
           .HasMaxLength(100)
           .HasConversion(simcardnumber => simcardnumber.Value, value => new SimCardNumber(value));
        builder.Property(x => x.Imei1)
          .IsRequired()
          .HasMaxLength(100)
          .HasConversion(imei => imei.Value, value => new Imei1(value));
        builder.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(i => i.AssignedTo);
        builder.Property(i => i.IsDeleted)
            .HasDefaultValue(false);
    }
}

