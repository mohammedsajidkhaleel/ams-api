using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Items.GetItem;
using ams.domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            	PO_NUMBER as PONumber
            FROM ITEM_RECEIPTS
            Where Id = @ItemReceiptId
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
                WHERE IRD.ITEM_RECEIPT_ID = @ItemReceiptId
                """;
            var details = await connection.QueryAsync<ItemReceiptDetailResponse>(
           query,
           new
           {
               request.ItemReceiptId
           });
            itemReceipt.Details = details.ToList();
        }
        return itemReceipt;
    }
}

