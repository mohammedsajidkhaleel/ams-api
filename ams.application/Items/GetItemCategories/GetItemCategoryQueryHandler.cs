using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using Dapper;

namespace ams.application.Items.GetItemCategories;
internal sealed class GetItemCategoryQueryHandler
    : IQueryHandler<GetItemCategoryQuery, IReadOnlyList<ItemCategoryResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public GetItemCategoryQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<IReadOnlyList<ItemCategoryResponse>>> Handle(GetItemCategoryQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            SELECT ic.id
            ,ic.name
            ,ic.description
            ,icc.name as parentcategory
            FROM item_categories ic
            left join item_categories icc
                on ic.parent_item_category_id = icc.id
            """;
        var itemCategories = await connection
            .QueryAsync<ItemCategoryResponse>(
            query
            );
        return itemCategories.ToList();
    }
}

