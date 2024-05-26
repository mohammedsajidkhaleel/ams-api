using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Employees.GetEmployees;
using ams.application.Reports.ActiveEmployees;
using ams.domain.Abstractions;

namespace ams.application.Reports.GetActiveEmployees;

public sealed class GetActiveEmployeeQueryHandler
    : IQueryHandler<GetActiveEmployeeQuery, IReadOnlyList<EmployeeResponse>>
{
    private ISqlConnectionFactory _sqlConnectionFactory;
    public GetActiveEmployeeQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<IReadOnlyList<EmployeeResponse>>> Handle(GetActiveEmployeeQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            SELECT E.ID,
            	E.CODE,
            	E.NAME,
            	E.SPONSOR_ID AS SPONSERID,
            	E.DEPARTMENT_ID AS DEPARTMENTID,
            	E.EMPLOYEE_CATEGORY_ID AS EMPOYEECATEGORYID,
            	E.NATIONALITY_ID AS NATIONALITYID,
            	E.EMPLOYEE_POSITION_ID AS EMPLOYEEPOSITIONID,
            	E.MOBILE,
            	E.EMAIL,
            	E.DOJ,
            	E.PROJECT_ID AS PROJECTID,
            	E.CREATION_DATE_TIME AS CREATIONDATETIME,
            	S.NAME AS SPONSORNAME,
            	D.NAME AS DEPARTMENTNAME,
            	EC.NAME AS EMPLOYEECATEGORYNAME,
            	N.NAME AS NATIONALITYNAME,
            	EP.NAME AS EMPLOYEEPOSITIONNAME,
            	P.NAME AS PROJECTNAME
            FROM EMPLOYEES E
            LEFT JOIN SPONSORS S ON S.ID = E.SPONSOR_ID
            LEFT JOIN DEPARTMENTS D ON D.ID = E.DEPARTMENT_ID
            LEFT JOIN EMPLOYEE_CAToGORIES EC ON EC.ID = E.EMPLOYEE_CATEGORY_ID
            LEFT JOIN NATIONALITIES N ON N.ID = E.NATIONALITY_ID
            LEFT JOIN EMPLOYEE_POSITIONS EP ON EP.ID = E.EMPLOYEE_POSITION_ID
            LEFT JOIN PROJECTS P ON P.ID = E.PROJECT_ID
            WHERE 
            """;
    }
}
