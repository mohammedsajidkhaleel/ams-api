using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Items.GetItemCategories;
using ams.domain.Abstractions;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.application.Employees.GetDepartments
{
    internal sealed class GetDepartmentQueryHandler
        : IQueryHandler<GetDepartmentQuery,
            IReadOnlyList<DepartmentResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetDepartmentQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        async Task<Result<IReadOnlyList<DepartmentResponse>>> IRequestHandler<GetDepartmentQuery, Result<IReadOnlyList<DepartmentResponse>>>.Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            var query = """
            WITH RECURSIVE department_hierarchy AS (
                SELECT 
                    d.id, 
                    d.name, 
                    d.parent_department_id, 
                    cast('' as text) AS parent_name
                FROM departments d
                  WHERE d.parent_department_id IS NULL
                UNION ALL
                SELECT 
                    d.id, 
                    d.name, 
                    d.parent_department_id, 
                    dh.name AS parent_name
                FROM departments d
                JOIN department_hierarchy dh 
                    ON d.parent_department_id = dh.id
            )
            SELECT id, name,parent_department_id as ParentDepartmentId, parent_name as parentdepartmentname
            FROM department_hierarchy  
            WHERE  ((@parentdepartmentid is null and parent_department_id is null) or parent_department_id = @parentdepartmentid);
            """;
            var departments = await connection
                .QueryAsync<DepartmentResponse>(
                query,
               new
               {
                   parentdepartmentid = request.parentDepartmentId
               }
                );
            return departments.ToList();
        }
    }
}
