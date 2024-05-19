using ams.application.Abstractions.Messaging;
using ams.application.ItemReceipts.GetItemReceipt;
using ams.domain.Abstractions;
using Dapper;
using ams.application.Abstractions.Data;
using ams.application.Items.GetItem;
using ams.domain.Items;
using MediatR;

namespace ams.application.ItemReceipts.GetForAssetConvert;

public sealed class GetforAssetConvertQueryHandler
    : IQueryHandler<GetForAssetConvertQuery, IReadOnlyList<ItemReceiptSerialNumberResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetforAssetConvertQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    async Task<Result<IReadOnlyList<ItemReceiptSerialNumberResponse>>> IRequestHandler<GetForAssetConvertQuery, Result<IReadOnlyList<ItemReceiptSerialNumberResponse>>>.Handle(GetForAssetConvertQuery request, CancellationToken cancellationToken)
    {
        var query = """
            SELECT IRS.ID AS ITEMRECEIPTSERIALID,
               	IRD.ITEM_ID AS ITEMID,
               	I.NAME AS "ITEMNAME",
               	IRS.SERIAL_NUMBER AS SERIALNUMBER,
               	IRS.ITEM_RECEIPT_DETAIL_ID AS ITEMRECEIPTDETAILID
            FROM ITEM_RECEIPT_ITEM_SERIAL_NUMBERS IRS
            INNER JOIN ITEM_RECEIPT_DETAILS IRD ON IRD.ID = IRS.ITEM_RECEIPT_DETAIL_ID
            INNER JOIN ITEMS I ON I.ID = IRD.ITEM_ID
            WHERE IRD.ITEM_RECEIPT_ID = @ItemReceiptId;
            """;
        using var connection = _sqlConnectionFactory.CreateConnection();
        var result = await connection
            .QueryAsync<ItemReceiptSerialNumberResponse>(
            query,
            new
            {
                request.ItemReceiptId
            }
            );
        return result.ToList();
    }
}
