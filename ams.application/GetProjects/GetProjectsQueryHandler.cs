using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Assets.GetAssets;
using ams.application.ItemReceipts.GetItemReceipts;
using ams.application.Models;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.GetProjects;
internal class GetProjectsQueryHandler
    : IQueryHandler<GetProjectsQuery, PaginatedResponse<ProjectsResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetProjectsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<PaginatedResponse<ProjectsResponse>>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            SELECT COUNT(*) AS COUNT
            FROM PROJECTS;

            SELECT ID,
            	Code AS Code,
            	Name as Name
            FROM Projects
            OFFSET @OFFSET
            LIMIT @LIMIT
            """;
        var response = new PaginatedResponse<ProjectsResponse>();
        using (var multi = await connection.QueryMultipleAsync(query,
            new
            {
                offset = request.pageIndex * request.pageSize,
                limit = request.pageSize
            }))
        {
            response.TotalItems = await multi.ReadFirstOrDefaultAsync<int>();
            response.Items = multi.Read<ProjectsResponse>().ToList();
        }
        return response;
    }
}

