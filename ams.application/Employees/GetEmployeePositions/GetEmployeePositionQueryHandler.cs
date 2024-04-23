using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.application.Employees.GetEmployeePositions
{
    internal sealed class GetEmployeePositionQueryHandler
        : IQueryHandler<GetEmployeePositionQuery,
            IReadOnlyList<EmployeePositionResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetEmployeePositionQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        async Task<Result<IReadOnlyList<EmployeePositionResponse>>> IRequestHandler<GetEmployeePositionQuery, Result<IReadOnlyList<EmployeePositionResponse>>>.Handle(GetEmployeePositionQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            var query = """
            select id,code,name from employee_positions
            """;
            var employeeCategories = await connection
                .QueryAsync<EmployeePositionResponse>(
                query
                );
            return employeeCategories.ToList();
        }
    }
}
