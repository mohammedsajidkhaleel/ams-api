using ams.domain.ItemReceipts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.application.ItemReceipts.GetItemReceipt
{
    public sealed class ItemReceiptResponse
    {
        public Guid Id { get; set; }
        public string PONumber { get; set; }
        public string ItemReceiptNumber { get; set; }
        public string? Description { get; set; } = string.Empty;
        public ItemReceiptStatus Status { get; private set; }
        public List<ItemReceiptDetailResponse> Details { get; set; } = new();
    }
}
