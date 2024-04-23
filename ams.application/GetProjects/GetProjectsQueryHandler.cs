using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.ItemReceipts.GetItemReceipts;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.GetProjects;
internal class GetProjectsQueryHandler
    : IQueryHandler<GetProjectsQuery,
        IReadOnlyList<ProjectsResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetProjectsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<IReadOnlyList<ProjectsResponse>>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            SELECT ID,
            	Code AS Code,
            	Name as Name
            FROM Projects
            """;
        var items = await connection
            .QueryAsync<ProjectsResponse>(
            query
            );
        return items.ToList();
    }
}

