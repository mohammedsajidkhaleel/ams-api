using ams.domain.Abstractions;
namespace ams.domain.Employees;
public sealed class Nationality : Entity
{
    public string Name { get; set; }
    public DateTimeOffset CreationDateTime { get; private set; }
    private Nationality()
    {
        
    }
    public Nationality(Guid id, string nationalityName) : base(id)
    {
        Name = nationalityName;
        CreationDateTime = DateTimeOffset.UtcNow;
    }
}

