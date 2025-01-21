using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Employees.GetSponsors;
using ams.domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.application.Employees.GetAccessories;

internal sealed class GetAccessoriesQueryHandler
    : IQueryHandler<GetAccessoriesQuery,
        IReadOnlyList<AccessoriesResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetAccessoriesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<IReadOnlyList<AccessoriesResponse>>> Handle(GetAccessoriesQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            select id,name from accessories where is_deleted = false order by name
            """;
        var accessories = await connection
            .QueryAsync<AccessoriesResponse>(
            query
            );
        return accessories.ToList();
    }
}
