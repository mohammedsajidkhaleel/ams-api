using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Models;
using ams.domain.Abstractions;
using Dapper;
using System.Collections.Immutable;

namespace ams.application.LicensedAssets.GetLicencedAssets;

internal class GetLicensedAssetQueryHandler
    : IQueryHandler<GetLicensedAssetQuery, PaginatedResponse<LicensedAssetResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetLicensedAssetQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<PaginatedResponse<LicensedAssetResponse>>> Handle(GetLicensedAssetQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            SELECT COUNT(*)
            FROM LICENSED_ASSETS LA
            INNER JOIN LICENSES L ON L.ID = LA.LICENSE_ID
            INNER JOIN ASSETS A ON A.ID = LA.ASSET_ID
            INNER JOIN ITEMS I ON I.ID = A.ITEM_ID
            LEFT JOIN EMPLOYEES E ON A.ASSIGNED_TO = E.ID
            WHERE LA.IS_DELETED = FALSE
            	AND LA.LICENSE_ID = @LicenseId;

            SELECT LA.ID,
            	LA.LICENSE_ID AS LicenseId,
            	LA.ASSET_ID AS AssetID,
            	L.NAME AS LICENSENAME,
            	A.NAME AS ASSETNAME,
            	I.NAME AS ITEMNAME,
            	A.CODE AS ASSETCODE,
            	E.NAME AS ASSIGNEDTO,
            	LA.CREATION_DATE_TIME AS CREATIONDATETIME
            FROM LICENSED_ASSETS LA
            INNER JOIN LICENSES L ON L.ID = LA.LICENSE_ID
            INNER JOIN ASSETS A ON A.ID = LA.ASSET_ID
            INNER JOIN ITEMS I ON I.ID = A.ITEM_ID
            LEFT JOIN EMPLOYEES E ON A.ASSIGNED_TO = E.ID
            WHERE LA.IS_DELETED = FALSE
            	AND LA.LICENSE_ID = @LicenseId
            OFFSET @OFFSET
            LIMIT @LIMIT;
            """;
        using (var multiResult = await connection.QueryMultipleAsync(query,
            new
            {
                licenseId = request.licenseId,
                offset = request.pageIndex * request.pageSize,
                limit = request.pageSize
            }))
        {
            return new PaginatedResponse<LicensedAssetResponse>
            {
                TotalItems = await multiResult.ReadFirstOrDefaultAsync<int>(),
                Items = multiResult.Read<LicensedAssetResponse>().ToList()
            };
        };
    }
}
