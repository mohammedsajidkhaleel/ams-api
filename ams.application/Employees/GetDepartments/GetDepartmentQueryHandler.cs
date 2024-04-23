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
            SELECT d.id
            ,d.name
            ,d.parent_department_id as ParentDepartmentId
            ,dd.name as parentdepartmentname
            FROM departments d
            left join departments dd
                on dd.parent_department_id = d.id
            """;
            var departments = await connection
                .QueryAsync<DepartmentResponse>(
                query
                );
            return departments.ToList();
        }
    }
}
