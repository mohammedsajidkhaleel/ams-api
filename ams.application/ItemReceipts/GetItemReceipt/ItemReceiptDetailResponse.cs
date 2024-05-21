namespace ams.application.ItemReceipts.GetItemReceipt
{
    public sealed class ItemReceiptDetailResponse
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public string ItemName { get; set; }
        public Guid ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }
        public decimal Quantity { get; set; }
        public string Description { get; set; }
        public List<string> SerialNumbers { get; set; }
    }

    public sealed class ItemReceiptSerialNumberResponse
    {
        public Guid ItemReceiptSerialId { get; set; }
        public Guid? ItemReceiptDetailId { get; set; }
        public string SerialNumber { get; set; }
        public Guid? ItemId { get; set; }
        public string ItemName { get; set; }
    }
}
