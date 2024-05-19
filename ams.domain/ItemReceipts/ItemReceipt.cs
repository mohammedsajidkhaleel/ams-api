using ams.domain.Abstractions;
using ams.domain.ItemReceipts.Events;
using ams.domain.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.domain.ItemReceipts
{
    public sealed class ItemReceipt : Entity
    {
        public string ItemReceiptNumber { get; set; }
        public string PONumber { get; private set; } = string.Empty;
        public DateTimeOffset CreationDateTime { get; private set; }
        public List<ItemReceiptDetail> Details { get; private set; } = new();
        public string? Description { get; set; } = string.Empty;
        public ItemReceiptStatus Status { get; private set; }
        public ItemReceipt(Guid id) : base(id)
        {

        }
        private ItemReceipt(Guid id,
            string poNumber,
            string itemReceiptNumber,
            string description,
            DateTimeOffset creationDateTime,
            ItemReceiptStatus status,
            List<ItemReceiptDetail> details) : base(id)
        {
            Id = id;
            CreationDateTime = creationDateTime;
            PONumber = poNumber;
            Details = details;
            ItemReceiptNumber = itemReceiptNumber;
            Description = description;
            Status = status;
        }

        public static ItemReceipt Create(string poNumber, string itemReceiptNumber, string description, ItemReceiptStatus status, List<ItemReceiptDetail> details)
        {
            var itemReceipt = new ItemReceipt(Guid.NewGuid(), poNumber, itemReceiptNumber, description, DateTimeOffset.UtcNow, status, details);
            itemReceipt.RaiseDomainEvent(new ItemReceiptCreatedDomainEvent(itemReceipt.Id));
            return itemReceipt;
        }
        public static ItemReceipt Edit(ItemReceipt itemReceipt, string poNumber, string description, List<ItemReceiptDetail> details)
        {
            itemReceipt.PONumber = poNumber;
            itemReceipt.Description = description;
            itemReceipt.Details = details;
            itemReceipt.RaiseDomainEvent(new ItemReceiptUpdatedDomainEvent(itemReceipt.Id));
            return itemReceipt;
        }
    }
}
