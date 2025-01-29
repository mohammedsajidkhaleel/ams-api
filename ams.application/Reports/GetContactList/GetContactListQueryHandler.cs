using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Employees.GetEmployeePositions;
using ams.application.Employees.GetEmployees;
using ams.application.Models;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.Reports.GetContactList;

public sealed class GetContactListQueryHandler
    : IQueryHandler<GetContactListQuery, IEnumerable<ContactListResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetContactListQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<IEnumerable<ContactListResponse>>> Handle(GetContactListQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var query = """
            SELECT E.ID,
            	E.CODE,
            	E.NAME,
            	E.SPONSOR_ID AS SPONSORID,
            	E.DEPARTMENT_ID AS DEPARTMENTID,
            	E.EMPLOYEE_CATEGORY_ID AS EMPLOYEECATEGORYID,
            	E.NATIONALITY_ID AS NATIONALITYID,
            	E.EMPLOYEE_POSITION_ID AS EMPLOYEEPOSITIONID,
            	E.MOBILE,
            	E.EMAIL,
            	E.DOJ,
            	E.PROJECT_ID AS PROJECTID,
            	E.CREATION_DATE_TIME AS CREATIONDATETIME,
            	S.NAME AS SPONSORNAME,
            	D.NAME AS DEPARTMENTNAME,
                DD.Id As ParentDepartmentId,
                DD.NAME AS ParentDepartmentName,
            	EC.NAME AS EMPLOYEECATEGORYNAME,
            	N.NAME AS NATIONALITYNAME,
            	EP.NAME AS EMPLOYEEPOSITIONNAME,
            	P.NAME AS PROJECTNAME
            FROM EMPLOYEES E
            LEFT JOIN SPONSORS S ON S.ID = E.SPONSOR_ID
            LEFT JOIN DEPARTMENTS D ON D.ID = E.DEPARTMENT_ID
            LEFT JOIN DEPARTMENTS DD ON D.Parent_Department_Id = DD.Id
            LEFT JOIN EMPLOYEE_CATEGORIES EC ON EC.ID = E.EMPLOYEE_CATEGORY_ID
            LEFT JOIN NATIONALITIES N ON N.ID = E.NATIONALITY_ID
            LEFT JOIN EMPLOYEE_POSITIONS EP ON EP.ID = E.EMPLOYEE_POSITION_ID
            LEFT JOIN PROJECTS P ON P.ID = E.PROJECT_ID
            WHERE E.STATUS = 1 
            order by D.NAME, E.NAME
            """;

        var employees = await connection
                      .QueryAsync<ContactListResponse>(
                      query
                      );
        return employees.ToList();
    }
}
