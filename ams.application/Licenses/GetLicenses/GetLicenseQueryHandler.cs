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
using System.Xml.Linq;

namespace ams.application.Licenses.GetLicenses;

internal sealed class GetLicenseQueryHandler
    : IQueryHandler<GetLicenseQuery,
        IReadOnlyList<LicenseResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetLicenseQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<IReadOnlyList<LicenseResponse>>> Handle(GetLicenseQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
SELECT ID,
	NAME,
	PURCHASED_DATE AS PURCHASEDDATE,
	EXPIRATION_DATE AS EXPIRATIONDATE,
	DESCRIPTION,
	CREATION_DATE_TIME AS CREATIONDATETIME,
	TOTAL_LICENSES AS TOTALLICENSES,
    po_number as PONUMBER
FROM LICENSES
WHERE IS_DELETED = 'FALSE'
""";
        var licenses = await connection
             .QueryAsync<LicenseResponse>(
             query
             );
        return licenses.ToList();
    }
}
