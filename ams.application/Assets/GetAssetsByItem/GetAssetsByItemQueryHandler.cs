
using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Models;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.Assets.GetAssetsByItem;
internal sealed class GetAssetsByItemQueryHandler
    : IQueryHandler<GetAssetsByItemQuery, PaginatedResponse<AssetsByItemReponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetAssetsByItemQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<PaginatedResponse<AssetsByItemReponse>>> Handle(GetAssetsByItemQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            select 1 as count;

            SELECT 
                a.po_number as ponumber,
                i.name as itemname,
            	count(a.status) as total,
                SUM(CASE WHEN a.status = 1 THEN 1 ELSE 0 END) AS available,
                SUM(CASE WHEN a.status = 2 THEN 1 ELSE 0 END) AS assigned,
                SUM(CASE WHEN a.status = 3 THEN 1 ELSE 0 END) AS maintenance,
            	SUM(CASE WHEN a.status = 4 THEN 1 ELSE 0 END) AS dicommissioned
            FROM 
                assets a
            inner join items i on a.item_id = i.id
            where a.is_deleted = false and a.po_number like @ponumber
            GROUP BY 
                a.po_number, i.name
            OFFSET @OFFSET
            LIMIT @LIMIT
            """;
        var response = new PaginatedResponse<AssetsByItemReponse>();
        using (var multi = await connection.QueryMultipleAsync(query,
            new
            {
                ponumber = '%' + request.poNumber + '%',
                offset = request.pageIndex * request.pageSize,
                limit = request.pageSize
            }))
        {
            response.TotalItems = await multi.ReadFirstOrDefaultAsync<int>();
            response.Items = multi.Read<AssetsByItemReponse>().ToList();
        }
        return response;
    }
}

