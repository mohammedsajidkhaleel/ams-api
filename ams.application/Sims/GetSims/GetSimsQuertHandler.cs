using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Assets.GetAssets;
using ams.application.Models;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.Sims.GetSims;

internal sealed class GetSimsQueryHandler
    : IQueryHandler<GetSimsQuery, PaginatedResponse<SimsResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetSimsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<PaginatedResponse<SimsResponse>>> Handle(GetSimsQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            SELECT COUNT(*) AS COUNT
            FROM SIMS
            WHERE IS_DELETED = FALSE;

            select s.id,
            s.service_account as ServiceAccount,
            s.service_number as ServiceNumber,
            s.sim_card_number as SimCardNumber,
            s.imei1 as Imei1,
            s.assigned_to as AssignedTo,
            e.name as assignedemployeename,
            e.code as assignedemployeecode,
            case when s.status = 1 then 'Assigned'
                 when s.status = 2 then 'Damaged'
            	 else 'Not Assigned' end as simstatus
            from sims s
            left join employees e on s.assigned_to = e.id
            WHERE s.is_deleted = false
            OFFSET @offset
            LIMIT @limit
            """;
        var response = new PaginatedResponse<SimsResponse>();
        using (var multi = await connection.QueryMultipleAsync(query,
            new
            {
                code = '%' + request.searchQuery + '%',
                offset = request.pageIndex * request.pageSize,
                limit = request.pageSize
            }))
        {
            response.TotalItems = await multi.ReadFirstOrDefaultAsync<int>();
            response.Items = multi.Read<SimsResponse>().ToList();
        }
        return response;
    }
}
