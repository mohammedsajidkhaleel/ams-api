using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Assets.GetAssets;
using ams.application.Employees.GetEmployeeAccessories;
using ams.application.Employees.GetEmployees;
using ams.application.Models;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.Employees.GetEmployee;

public sealed class GetEmployeeQueryHandler
    : IQueryHandler<GetEmployeeQuery, EmployeeDetailResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetEmployeeQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<EmployeeDetailResponse>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var query = """
            SELECT E.ID,
            	E.CODE,
            	E.NAME,
            	E.MOBILE,
            	E.EMAIL,
            	E.DOJ,
            	S.NAME AS SPONSOR,
            	D.NAME AS SubDEPARTMENT,
                DD.NAME AS Department,
            	EC.NAME AS EMPLOYEECATEGORY,
            	N.NAME AS NATIONALITY,
            	EP.NAME AS EMPLOYEEPOSITION,
            	P.NAME AS PROJECT
            FROM EMPLOYEES E
            LEFT JOIN SPONSORS S ON S.ID = E.SPONSOR_ID
            LEFT JOIN DEPARTMENTS D ON D.ID = E.DEPARTMENT_ID
            LEFT JOIN DEPARTMENTS DD ON D.Parent_Department_Id = DD.Id
            LEFT JOIN EMPLOYEE_CATOGORIES EC ON EC.ID = E.EMPLOYEE_CATEGORY_ID
            LEFT JOIN NATIONALITIES N ON N.ID = E.NATIONALITY_ID
            LEFT JOIN EMPLOYEE_POSITIONS EP ON EP.ID = E.EMPLOYEE_POSITION_ID
            LEFT JOIN PROJECTS P ON P.ID = E.PROJECT_ID
            WHERE E.STATUS = 1 
            and e.id = @employeeid
            order by E.NAME;

            SELECT ea.id,
            ea.accessory_id AS AccessoryId,
            a.name AS AccessoryName,
               	ea.creation_date_time AS CREATIONDATETIME
            FROM employee_accessories ea
            INNER JOIN accessories a ON a.ID = ea.accessory_id
            WHERE ea.IS_DELETED = FALSE
            AND ea.employee_id = @employeeid;

            SELECT A.Id, A.CODE AS Code,
            	A.NAME AS Name,
            	I.NAME AS ItemName,
                A.Serial_Number as SerialNumber
            FROM ASSETS A
            LEFT JOIN EMPLOYEES E ON A.ASSIGNED_TO = E.ID
            LEFT JOIN ITEMS I ON A.ITEM_ID = I.ID
            WHERE A.ASSIGNED_TO = @EmployeeId
            """;

        using (var multi = await connection.QueryMultipleAsync(query,
           new
           {
               employeeid = request.employeeId
           }))
        {
            var response = await multi.ReadFirstOrDefaultAsync<EmployeeDetailResponse>();
            if (response == null)
            {
                return new EmployeeDetailResponse();
            }
            response.AssignedAccessories = multi.Read<EmployeeAccessoryResponse>().ToList();
            response.AssignedAssets = multi.Read<AssetsResponse>().ToList();
            return response;
        }
    }
}
