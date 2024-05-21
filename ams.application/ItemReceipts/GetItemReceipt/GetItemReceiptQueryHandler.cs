using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.ItemReceipts.GetItemReceipt;
internal sealed class GetItemReceiptQueryHandler
    : IQueryHandler<GetItemReceiptQuery, ItemReceiptResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetItemReceiptQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<ItemReceiptResponse>> Handle(GetItemReceiptQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            SELECT ID as Id,
            	ITEM_RECEIPT_NUMBER as ItemReceiptNumber,
            	PO_NUMBER as PONumber,
                Description,
                Status
            FROM ITEM_RECEIPTS
            Where Id = @ItemReceiptId;
            """;
        ItemReceiptResponse? itemReceipt = await connection.QueryFirstOrDefaultAsync<ItemReceiptResponse>(
           query,
           new
           {
               request.ItemReceiptId
           });
        if (itemReceipt != null)
        {
            query = """
                SELECT IRD.ID AS ID,
                	IRD.ITEM_ID AS ITEMID,
                	I."name" AS ITEMNAME,
                	IC."name" AS ITEMCATEGORYNAME,
                    I."item_category_id" As ItemCategoryId,
                	IRD.QUANTITY,
                	IRD.DESCRIPTION
                FROM ITEM_RECEIPT_DETAILS IRD
                INNER JOIN ITEMS I ON I.ID = IRD.Item_Id
                INNER JOIN ITEM_CATEGORIES IC ON I.ITEM_CATEGORY_ID = IC.ID
                WHERE IRD.ITEM_RECEIPT_ID = @ItemReceiptId;

                SELECT IRS.SERIAL_NUMBER AS SERIALNUMBER,
                IRS.ITEM_RECEIPT_DETAIL_ID As ITEMRECEIPTDETAILID
                FROM ITEM_RECEIPT_ITEM_SERIAL_NUMBERS IRS
                INNER JOIN ITEM_RECEIPT_DETAILS IRD ON IRD.ID = IRS.ITEM_RECEIPT_DETAIL_ID
                WHERE IRD.ITEM_RECEIPT_ID = @ItemReceiptId;
                """;

            using (var multResult = await connection.QueryMultipleAsync(query,
                new
                {
                    request.ItemReceiptId
                }))
            {
                var receiptDetails = multResult.Read<ItemReceiptDetailResponse>().ToList();
                var serialNumbers = multResult.Read<ItemReceiptSerialNumberResponse>().ToList();
                if (serialNumbers != null && serialNumbers.Count > 0)
                {
                    foreach (var itemDetail in receiptDetails)
                        itemDetail.SerialNumbers = serialNumbers
                            .Where(i => i.ItemReceiptDetailId == itemDetail.Id)
                            .Select(i => i.SerialNumber).ToList();
                }
                itemReceipt.Details = receiptDetails;
            };
        }
        return itemReceipt;
    }
}

