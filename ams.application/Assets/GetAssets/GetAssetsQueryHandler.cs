
using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Models;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.Assets.GetAssets;
internal sealed class GetAssetsQueryHandler
    : IQueryHandler<GetAssetsQuery, PaginatedResponse<AssetsResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetAssetsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<PaginatedResponse<AssetsResponse>>> Handle(GetAssetsQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            SELECT COUNT(*) AS COUNT
            FROM ASSETS
            WHERE IS_DELETED = FALSE AND (@CODE IS NULL OR @CODE = '' OR 
            CODE LIKE @CODE);

            SELECT A.ID,
            	A.CODE,
            	A.NAME,
            	A.SERIAL_NUMBER AS SERIALNUMBER,
            	A.ASSIGNED_TO AS ASSIGNEDTO,
            	A.PROJECT_ID AS PROJECTID,
            	A.CREATION_DATE_TIME AS CREATIONDATETIME,
            	E.NAME AS EMPLOYEENAME,
            	P.NAME AS PROJECTNAME,
            	A.DESCRIPTION,
            	A.STATUS,
            	A.PO_NUMBER AS PONumber,
            	A.ITEM_ID AS ITEMID,
            	I.NAME AS ITEMNAME
            FROM ASSETS A
            LEFT JOIN EMPLOYEES E ON E.ID = A.ASSIGNED_TO
            LEFT JOIN PROJECTS P ON P.ID = E.PROJECT_ID
            LEFT JOIN ITEMS I ON I.ID = A.ITEM_ID
            WHERE A.IS_DELETED = FALSE
            AND (@CODE IS NULL OR @CODE = '' OR 
            A.CODE LIKE @CODE)
            OFFSET @OFFSET
            LIMIT @LIMIT
            """;
        var response = new PaginatedResponse<AssetsResponse>();
        using (var multi = await connection.QueryMultipleAsync(query,
            new
            {
                code = '%' +request.assetCode + '%',
                offset = request.pageIndex * request.pageSize,
                limit = request.pageSize
            }))
        {
            response.TotalItems = await multi.ReadFirstOrDefaultAsync<int>();
            response.Items = multi.Read<AssetsResponse>().ToList();
        }
        return response;
    }
}

