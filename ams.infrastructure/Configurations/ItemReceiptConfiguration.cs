using ams.domain.ItemReceipts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.infrastructure.Configurations
{
    internal sealed class ItemReceiptConfiguration :
        IEntityTypeConfiguration<ItemReceipt>
    {
        public void Configure(EntityTypeBuilder<ItemReceipt> builder)
        {
            builder.ToTable("item_receipts");
            builder.HasKey(item => item.Id);
            builder.HasIndex(item => item.ItemReceiptNumber).IsUnique();
            builder.Property(i => i.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
