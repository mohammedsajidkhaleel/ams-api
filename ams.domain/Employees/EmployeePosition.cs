using ams.domain.Abstractions;

namespace ams.domain.Employees;
public sealed class EmployeePosition : Entity
{
    public string? Code { get; private set; }
    public string Name { get; private set; }
    public DateTimeOffset CreationDateTime { get; private set; }
    private EmployeePosition()
    {
        
    }
    public EmployeePosition(Guid id, string employeePositionCode, string employeePositionName) : base(id)
    {
        Code = employeePositionCode;
        Name = employeePositionName;
        CreationDateTime = DateTimeOffset.UtcNow;
    }
}

