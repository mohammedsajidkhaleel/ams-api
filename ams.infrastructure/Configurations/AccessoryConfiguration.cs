using ams.domain.Accessories;
using ams.domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ams.infrastructure.Configurations;
internal sealed class AccessoryConfiguration : IEntityTypeConfiguration<Accessory>
{
    public void Configure(EntityTypeBuilder<Accessory> builder)
    {
        builder.ToTable("accessories");
        builder.HasKey(accessory => accessory.Id);
        builder.Property(accessory => accessory.Name)
            .HasMaxLength(250);
        builder.HasData(
            new Accessory { Id = new Guid("129f3a50-9939-44d2-a12d-b6dd8c434e89"), Name = "Laptop Bag", IsDeleted = false },
            new Accessory { Id = new Guid("3b2af4e0-6ea6-474e-9d5a-aa488f855a64"), Name = "Wireless KB/M", IsDeleted = false },
            new Accessory { Id = new Guid("701a9764-9392-42e6-9bae-a0b71904c0d9"), Name = "Headset", IsDeleted = false },
            new Accessory { Id = new Guid("c544dd6a-75f8-4148-9ff7-9d480684ca67"), Name = "Mouse", IsDeleted = false },
            new Accessory { Id = new Guid("f266170a-b637-4119-b417-9b9c754a3c45"), Name = "Webcam", IsDeleted = false },
            new Accessory { Id = new Guid("f87a1e53-63f3-4586-a809-06731431bc07"), Name = "Docking Station", IsDeleted = false },
            new Accessory { Id = new Guid("e9f09312-4a09-4e26-abfb-7c9453cb4d28"), Name = "External Hard Drive/SSD ", IsDeleted = false },
            new Accessory { Id = new Guid("624b4b3a-0e18-4969-b939-a1fca8b26d51"), Name = "Keyboard", IsDeleted = false },
            new Accessory { Id = new Guid("e50d5693-a711-4184-97f9-436bc76f0420"), Name = "USB Hub", IsDeleted = false },
            new Accessory { Id = new Guid("f23bcb62-63bd-4ae9-ac8f-432871f8ae54"), Name = "Screen Protector", IsDeleted = false },
            new Accessory { Id = new Guid("df1d9565-21f9-44bc-9a75-9635d4c82c4e"), Name = "Cable Management Accessories", IsDeleted = false },
            new Accessory { Id = new Guid("40dd02ed-29eb-423c-b7d7-dd96d035692e"), Name = "Surge Protector/Power Strip ", IsDeleted = false },
            new Accessory { Id = new Guid("19105bc4-0783-48c5-8736-e1e3b85b3781"), Name = "Laptop Stand", IsDeleted = false },
            new Accessory { Id = new Guid("e3414d50-27e8-43dd-b0d6-9d655c2603c3"), Name = "Cleaning Kits", IsDeleted = false },
            new Accessory { Id = new Guid("071f7121-0f58-4c31-8152-1bd37a1be208"), Name = "Laptop Sleeve", IsDeleted = false },
            new Accessory { Id = new Guid("a5b2a115-71e0-41c9-91d6-8b6c06ab351b"), Name = "Backpack", IsDeleted = false },
            new Accessory { Id = new Guid("f3a32464-31f6-4aba-a06f-34da057383ff"), Name = "USB Dongle", IsDeleted = false },
            new Accessory { Id = new Guid("74941def-6a9b-4067-9f0a-891d47d9b098"), Name = "Wireless Keyboard and Mouse", IsDeleted = false }
        );
    }
}

