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

namespace ams.application.Employees.GetEmployeeCategories
{
    internal sealed class GetEmployeeCategoryQueryHandler
        : IQueryHandler<GetEmployeeCategoryQuery,
            IReadOnlyList<EmployeeCategoryResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetEmployeeCategoryQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        async Task<Result<IReadOnlyList<EmployeeCategoryResponse>>> IRequestHandler<GetEmployeeCategoryQuery, Result<IReadOnlyList<EmployeeCategoryResponse>>>.Handle(GetEmployeeCategoryQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            var query = """
            select id,code,name from employee_catogories
            """;
            var employeeCategories = await connection
                .QueryAsync<EmployeeCategoryResponse>(
                query
                );
            return employeeCategories.ToList();
        }
    }
}
