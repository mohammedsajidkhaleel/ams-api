
using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Items.GetItem;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.ItemReceipts.GetItemReceipts;
internal sealed class GetItemReceiptsQueryHandler
    : IQueryHandler<GetItemReceiptsQuery, IReadOnlyList<ItemReceiptsResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetItemReceiptsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<IReadOnlyList<ItemReceiptsResponse>>> Handle(GetItemReceiptsQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            SELECT ID,
            	ITEM_RECEIPT_NUMBER AS ITEMRECEIPTNUMBER,
            	PO_NUMBER as PONumber,
            	CREATION_DATE_TIME AS CREATIONDATETIME,
            	DESCRIPTION,
            	STATUS
            FROM ITEM_RECEIPTS
            """;
        var items = await connection
            .QueryAsync<ItemReceiptsResponse>(
            query
            );
        return items.ToList();
    }
}

