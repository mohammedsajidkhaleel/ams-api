using ams.domain.Abstractions;

namespace ams.domain.Accessories;

public sealed class Accessory : Entity
{
    public string Name { get; set; }
    public Accessory()
    {
        
    }
    public Accessory(string name)
    {
        Name = name;
    }
}
