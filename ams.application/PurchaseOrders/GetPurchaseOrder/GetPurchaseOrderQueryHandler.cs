using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.PurchaseOrders.GetPurchaseOrder;

public sealed class GetPurchaseOrderQueryHandler
    : IQueryHandler<GetPurchaseOrderQuery, PurchaseOrderDetailResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetPurchaseOrderQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<PurchaseOrderDetailResponse>> Handle(GetPurchaseOrderQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            select id,
            po_number as ponumber,
            purchase_date as purchasedate,
            description
            from purchase_orders
            where Id = @purchaseOrderId;

            select pd.item_id as itemid,
            i.name as itemname,
            pd.quantity
            from purchase_order_items pd
            inner join items i on pd.item_id = i.id 
            where purchase_order_id = @purchaseOrderId
            """;
        using (var multiQuery = await connection.QueryMultipleAsync(query, new
        {
            purchaseorderid = request.purchaseOrderId
        }))
        {
            var purchaseOrder = await multiQuery.ReadFirstOrDefaultAsync<PurchaseOrderDetailResponse>();
            if (purchaseOrder == null)
            {
                return new PurchaseOrderDetailResponse();
            }
            purchaseOrder.Items = (await multiQuery.ReadAsync<PurchaseOrderItemDetailResponse>()).AsList();
            return purchaseOrder;
        }
    }
}
