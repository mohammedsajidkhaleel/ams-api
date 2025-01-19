using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Models;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.LicensedEmployees.GetLicencedEmployees;

internal class GetLicensedEmployeeQueryHandler
    : IQueryHandler<GetLicensedEmployeeQuery, PaginatedResponse<LicensedEmployeeResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetLicensedEmployeeQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<PaginatedResponse<LicensedEmployeeResponse>>> Handle(GetLicensedEmployeeQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            SELECT COUNT(*)
            FROM LICENSED_EMPLOYEES LA
            INNER JOIN LICENSES L ON L.ID = LA.LICENSE_ID
            INNER JOIN EMPLOYEES A ON A.ID = LA.EMPLOYEE_ID
            WHERE LA.IS_DELETED = FALSE
            	AND LA.LICENSE_ID = @licenseid;

            SELECT LE.ID,
            	LE.LICENSE_ID AS LicenseId,
            	LE.EMPLOYEE_ID AS EmployeeID,
            	L.NAME AS LICENSENAME,
            	E.NAME AS EmployeeNAME,
            	E.CODE AS EmployeeCODE,
            	LE.CREATION_DATE_TIME AS CREATIONDATETIME
            FROM LICENSED_EMPLOYEES LE
            INNER JOIN LICENSES L ON L.ID = LE.LICENSE_ID
            INNER JOIN EMPLOYEES E ON E.ID = LE.EMPLOYEE_ID
            WHERE LE.IS_DELETED = FALSE
            	AND LE.LICENSE_ID = @licenseid
            OFFSET @OFFSET
            LIMIT @LIMIT;
            """;
        using (var multiResult = await connection.QueryMultipleAsync(query,
            new
            {
                licenseid = request.licenseId,
                offset = request.pageIndex * request.pageSize,
                limit = request.pageSize
            }))
        {
            return new PaginatedResponse<LicensedEmployeeResponse>
            {
                TotalItems = await multiResult.ReadFirstOrDefaultAsync<int>(),
                Items = multiResult.Read<LicensedEmployeeResponse>().ToList()
            };
        };
    }
}
