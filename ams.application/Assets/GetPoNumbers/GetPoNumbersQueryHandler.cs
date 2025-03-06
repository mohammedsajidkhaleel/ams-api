
using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Models;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.Assets.GetPoNumbers;
internal sealed class GetPoNumbersQueryHandler
    : IQueryHandler<GetPoNumbersQuery, PaginatedResponse<PoNumbersReponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetPoNumbersQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<PaginatedResponse<PoNumbersReponse>>> Handle(GetPoNumbersQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            select count(po_number) as count from 
            (select distinct po_number from assets where is_deleted='false') t
            where (@ponumber IS NULL OR @ponumber = '' OR 
            po_number LIKE @ponumber);

            select distinct po_number as ponumber from assets
            where is_deleted='false'
            and (@ponumber IS NULL OR @ponumber = '' OR 
            po_number LIKE @ponumber)
            order by po_number
            OFFSET @OFFSET
            LIMIT @LIMIT
            """;
        var response = new PaginatedResponse<PoNumbersReponse>();
        using (var multi = await connection.QueryMultipleAsync(query,
            new
            {
                ponumber = '%' + request.poNumber + '%',
                offset = request.pageIndex * request.pageSize,
                limit = request.pageSize
            }))
        {
            response.TotalItems = await multi.ReadFirstOrDefaultAsync<int>();
            response.Items = multi.Read<PoNumbersReponse>().ToList();
        }
        return response;
    }
}

