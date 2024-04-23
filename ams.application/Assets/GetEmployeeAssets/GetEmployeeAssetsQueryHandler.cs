using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.Assets.GetEmployeeAssets;
internal sealed class GetEmployeeAssetsQueryHandler
    : IQueryHandler<GetEmployeeAssetsQuery, IReadOnlyList<EmployeeAssetResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetEmployeeAssetsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<IReadOnlyList<EmployeeAssetResponse>>> Handle(GetEmployeeAssetsQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            SELECT A.CODE AS ASSETCODE,
            	A.NAME AS ASSETNAME,
            	I.NAME AS ITEMNAME
            FROM ASSETS A
            LEFT JOIN EMPLOYEES E ON A.ASSIGNED_TO = E.ID
            LEFT JOIN ITEMS I ON A.ITEM_ID = I.ID
            WHERE A.ASSIGNED_TO = @EmployeeId
            """;
        var assets = await connection
            .QueryAsync<EmployeeAssetResponse>(
            query,
            new
            {
                request.EmployeeId
            }
            );
        return assets.ToList();
    }
}

