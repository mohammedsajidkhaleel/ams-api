using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Models;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.PurchaseOrders.GetPurchaseOrders;
internal sealed class GetPurchaseOrdersQueryHandler
    : IQueryHandler<GetPurchaseOrdersQuery, PaginatedResponse<PurchaseOrderResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetPurchaseOrdersQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<PaginatedResponse<PurchaseOrderResponse>>> Handle(GetPurchaseOrdersQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        string searchQuery = null;
        //if (!string.IsNullOrWhiteSpace(request.searchQuery))
        //    searchQuery = '%' + request.searchQuery + '%';

        var query = """
            SELECT COUNT(*) AS COUNT
            from purchase_orders
            where is_deleted = 'false'
            AND (@searchquery is null or po_number like @searchquery);

            select id,
            po_number as poNumber, 
            purchase_date as purchasedate ,
            creation_date_time as creationdatetime
            from purchase_orders
            where is_deleted = 'false'
            AND (@searchquery is null or po_number like @searchquery)
            order by purchase_date desc
            OFFSET @OFFSET
            LIMIT @LIMIT
            """;

        var response = new PaginatedResponse<PurchaseOrderResponse>();
        using (var multi = await connection.QueryMultipleAsync(query,
           new
           {
               searchquery = '%' + request.searchQuery.ToLower() + '%',
               offset = request.pageIndex * request.pageSize,
               limit = request.pageSize
           }))
        {
            response.TotalItems = await multi.ReadFirstOrDefaultAsync<int>();
            response.Items = multi.Read<PurchaseOrderResponse>().ToList();
        }
        return response;
    }
}

