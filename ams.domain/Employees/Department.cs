using ams.domain.Abstractions;

namespace ams.domain.Employees;
public sealed class Department : Entity
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public Guid? ParentDepartmentId { get; private set; }
    public DateTimeOffset CreationDateTime { get; private set; }
    private Department()
    {
        
    }
    public Department(Guid id, string departmentCode, string departmentName, Guid? parentDepartmentId) : base(id)
    {
        Code = departmentCode;
        Name = departmentName;
        ParentDepartmentId = parentDepartmentId;
        CreationDateTime = DateTimeOffset.UtcNow;
    }
}
