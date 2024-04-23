
using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.Assets.GetAssets;
internal sealed class GetAssetsQueryHandler
    : IQueryHandler<GetAssetsQuery, IReadOnlyList<AssetsResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetAssetsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<IReadOnlyList<AssetsResponse>>> Handle(GetAssetsQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
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
            """;
        var assets = await connection
            .QueryAsync<AssetsResponse>(
            query
            );
        return assets.ToList();
    }
}

