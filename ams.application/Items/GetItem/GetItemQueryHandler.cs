using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.Items.GetItem;
internal sealed class GetItemQueryHandler
    : IQueryHandler<GetItemQuery, IReadOnlyList<ItemResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetItemQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<IReadOnlyList<ItemResponse>>> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            SELECT i.id
            ,i.name
            ,i.description
            ,ic.name as itemcategory
            FROM items i
            inner join item_categories ic
                on i.item_category_id = ic.id
            """;
        var items = await connection
            .QueryAsync<ItemResponse>(
            query
            );
        return items.ToList();
    }
}

