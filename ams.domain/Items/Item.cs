using ams.domain.Abstractions;

namespace ams.domain.Items;
public sealed class Item : Entity

{
    public Item(Guid id, string name, Guid itemCategoryId, string description) 
        : base(id)
    {
        Name = name;
        ItemCategoryId = itemCategoryId;
        Description = description;
        CreationDateTime = DateTimeOffset.UtcNow;
    }
    public string Name { get; private set; } = string.Empty;
    public Guid ItemCategoryId { get; private set; }
    public string? Description { get; private set; } = string.Empty;
    public DateTimeOffset CreationDateTime { get; private set; }
}

