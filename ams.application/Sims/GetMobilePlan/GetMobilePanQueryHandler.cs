using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Items.GetItemCategories;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.Sims.GetMobilePlan;
public sealed class GetMobilePanQueryHandler
    : IQueryHandler<GetMobilePlanQuery, IReadOnlyList<MobilePlanResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetMobilePanQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<IReadOnlyList<MobilePlanResponse>>> Handle(GetMobilePlanQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            SELECT id,name
            FROM mobile_plans
            where is_deleted = false
            order by order_index
            """;
        var result = await connection
            .QueryAsync<MobilePlanResponse>(
            query
            );
        return result.ToList();
    }
}
