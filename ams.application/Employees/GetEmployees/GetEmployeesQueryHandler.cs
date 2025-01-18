﻿using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Assets.GetAssets;
using ams.application.Models;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.Employees.GetEmployees;
internal sealed class GetEmployeesQueryHandler
    : IQueryHandler<GetEmployeesQuery, PaginatedResponse<EmployeeResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetEmployeesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<PaginatedResponse<EmployeeResponse>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        string searchQuery = null;
        if (string.IsNullOrWhiteSpace(request.searchQuery))
            searchQuery = '%' + request.searchQuery + '%';

        var query = """
            SELECT COUNT(*) AS COUNT
            FROM EMPLOYEES
            WHERE STATUS = 1 
            AND (@projectid is null or Project_Id = @projectid)
            AND (@searchquery is null or Name like @searchquery);

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
            	EC.NAME AS EMPLOYEECATEGORYNAME,
            	N.NAME AS NATIONALITYNAME,
            	EP.NAME AS EMPLOYEEPOSITIONNAME,
            	P.NAME AS PROJECTNAME
            FROM EMPLOYEES E
            LEFT JOIN SPONSORS S ON S.ID = E.SPONSOR_ID
            LEFT JOIN DEPARTMENTS D ON D.ID = E.DEPARTMENT_ID
            LEFT JOIN EMPLOYEE_CATOGORIES EC ON EC.ID = E.EMPLOYEE_CATEGORY_ID
            LEFT JOIN NATIONALITIES N ON N.ID = E.NATIONALITY_ID
            LEFT JOIN EMPLOYEE_POSITIONS EP ON EP.ID = E.EMPLOYEE_POSITION_ID
            LEFT JOIN PROJECTS P ON P.ID = E.PROJECT_ID
            WHERE E.STATUS = 1 
            AND (@projectid is null or E.Project_Id = @projectid)
            AND (@searchquery is null or E.Name like @searchquery)
            order by E.NAME
            OFFSET @offset ROWS
            FETCH NEXT @limit ROWS ONLY;
            """;

        var response = new PaginatedResponse<EmployeeResponse>();
        using (var multi = await connection.QueryMultipleAsync(query,
           new
           {
               projectid = request.projectId,
               searchquery = searchQuery,
               offset = request.pageIndex * request.pageSize,
               limit = request.pageSize
           }))
        {
            response.TotalItems = await multi.ReadFirstOrDefaultAsync<int>();
            response.Items = multi.Read<EmployeeResponse>().ToList();
        }
        return response;
    }
}

