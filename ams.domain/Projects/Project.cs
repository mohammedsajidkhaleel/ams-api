using ams.domain.Abstractions;

namespace ams.domain.Projects;
public sealed class Project : Entity
{
    public string? Code { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public DateTimeOffset CreationDateTime { get; private set; }
    private Project()
    {
        
    }
    public Project(Guid id, string projectCode, string projectName) : base(id)
    {
        Code = projectCode;
        Name = projectName;
        CreationDateTime = DateTimeOffset.UtcNow;
    }
}

