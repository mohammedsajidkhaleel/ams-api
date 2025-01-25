using ams.domain.Abstractions;

namespace ams.domain.Sims;

public sealed class MobilePlan
    : Entity
{
    public string Name { get; set; }
    public int OrderIndex { get; set; }
    public MobilePlan(Guid id, string name, int orderIndex)
    {
        Id = id;
        Name = name;
        OrderIndex = orderIndex;
    }
}
