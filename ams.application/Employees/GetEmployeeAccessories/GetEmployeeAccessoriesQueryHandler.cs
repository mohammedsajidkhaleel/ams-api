using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.LicensedEmployees.GetLicencedEmployees;
using ams.application.Models;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.Employees.GetEmployeeAccessories;

public sealed class GetEmployeeAccessoriesQueryHandler
    : IQueryHandler<GetEmployeeAccessoriesQuery, PaginatedResponse<EmployeeAccessoryResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetEmployeeAccessoriesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<PaginatedResponse<EmployeeAccessoryResponse>>> Handle(GetEmployeeAccessoriesQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            SELECT COUNT(*)
            FROM employee_accessories 
            WHERE IS_DELETED = FALSE
            	AND employee_id = @employeeid;

            SELECT ea.id,
            ea.accessory_id AS AccessoryId,
            a.name AS AccessoryName,
               	ea.creation_date_time AS CREATIONDATETIME
            FROM employee_accessories ea
            INNER JOIN accessories a ON a.ID = ea.accessory_id
            WHERE ea.IS_DELETED = FALSE
            	AND ea.employee_id = @employeeid
            OFFSET @OFFSET
            LIMIT @LIMIT;
            """;
        using (var multiResult = await connection.QueryMultipleAsync(query,
            new
            {
                employeeid = request.employeeId,
                offset = request.pageIndex * request.pageSize,
                limit = request.pageSize
            }))
        {
            return new PaginatedResponse<EmployeeAccessoryResponse>
            {
                TotalItems = await multiResult.ReadFirstOrDefaultAsync<int>(),
                Items = multiResult.Read<EmployeeAccessoryResponse>().ToList()
            };
        };
    }
}
