using ams.domain.Sims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ams.infrastructure.Configurations;
internal sealed class MobilePlanConfiguration : IEntityTypeConfiguration<MobilePlan>
{
    public void Configure(EntityTypeBuilder<MobilePlan> builder)
    {
        builder.ToTable("mobile_plans");
        builder.HasKey(x => x.Id);
        builder.Property(item => item.Name)
           .HasMaxLength(250);
        builder.HasIndex(i => i.Name)
            .IsUnique();
        builder.HasData([
            new MobilePlan(new Guid("3aa1a0a0-4178-47b1-8200-ab1a238c0274"),"50",1 ),
            new MobilePlan(new Guid("166fbe6a-ad4a-4d13-99dc-f86155aa14c7"),"80",2 ),
            new MobilePlan(new Guid("73450b9a-575d-4eb4-b2c4-3400d3f623b1"),"120",3 ),
            new MobilePlan(new Guid("d298bb26-6c1f-46cb-a675-aa29d08e23bf"),"230",4 ),
            new MobilePlan(new Guid("cae99f89-1296-4b32-827e-6b836f2187fa"),"450",5 ),
            new MobilePlan(new Guid("5677a4d2-d209-403e-b1f0-71a838c5ced3"),"800" ,6)
            ]);
    }
}