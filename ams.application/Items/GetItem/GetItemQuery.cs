using ams.application.Abstractions.Messaging;

namespace ams.application.Items.GetItem;
public sealed record GetItemQuery(
    string searchText,
    Guid? itemCategoryId) : IQuery<IReadOnlyList<ItemResponse>>;

