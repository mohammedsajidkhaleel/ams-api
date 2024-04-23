using ams.domain.Employees;
using ams.domain.ItemReceipts;
using ams.domain.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.infrastructure.Configurations
{
    internal sealed class ItemReceiptDetailConfiguration :
        IEntityTypeConfiguration<ItemReceiptDetail>
    {
        public void Configure(EntityTypeBuilder<ItemReceiptDetail> builder)
        {
            builder.ToTable("item_receipt_details");
            builder.HasKey(item => item.Id);
            builder.HasOne<Item>()
                .WithMany()
                .HasForeignKey(i => i.ItemId);
        }
    }
}
