namespace ams.domain.Items;
public sealed class ItemCategory
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; } = string.Empty;
    public DateTimeOffset CreationDateTime { get; private set; }
    public Guid? ParentItemCategoryId { get; private set; }
}

