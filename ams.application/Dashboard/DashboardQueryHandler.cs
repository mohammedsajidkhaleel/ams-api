using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Dashboard;
using ams.domain.Abstractions;
using Dapper;
using MediatR;

namespace ams.application.Employees.GetDepartments
{
    internal sealed class DashboardQueryHandler
        : IQueryHandler<DashboardQuery,
            DashboardResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public DashboardQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        async Task<Result<DashboardResponse>> IRequestHandler<DashboardQuery, Result<DashboardResponse>>.Handle(DashboardQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            var query = """
            SELECT COUNT(*) as totalAssets
            FROM ASSETS
            WHERE IS_DELETED = FALSE;


            SELECT COUNT(*) as totalProjects
            FROM PROJECTS
            WHERE IS_DELETED = FALSE;


            SELECT COUNT(*) as totalEmployees
            FROM EMPLOYEES
            WHERE IS_DELETED = FALSE;


            SELECT COUNT(*) as totalLicenses
            FROM LICENSES
            WHERE IS_DELETED = FALSE;

            """;

            using (var multi = await connection.QueryMultipleAsync(query, cancellationToken))
            {
                var dashbordResponse = new DashboardResponse
                {
                    TotalAssets = multi.Read<int>().FirstOrDefault(),
                    TotalProjects = multi.Read<int>().FirstOrDefault(),
                    TotalEmployees = multi.Read<int>().FirstOrDefault(),
                    TotalLicenses = multi.Read<int>().FirstOrDefault(),
                };
                return dashbordResponse;
            }
        }
    }
}
