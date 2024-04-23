using ams.application.Abstractions.Messaging;

namespace ams.application.Items.GetItemCategories;
public sealed record GetItemCategoryQuery(
    string searchText,
    Guid? itemCategoryId) : IQuery<IReadOnlyList<ItemCategoryResponse>>;

