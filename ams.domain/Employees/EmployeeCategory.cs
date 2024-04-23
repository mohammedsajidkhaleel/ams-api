
using ams.domain.Abstractions;

namespace ams.domain.Employees;
public sealed class EmployeeCategory : Entity
{
    public string? Code { get; private set; }
    public string Name { get; private set; }
    public DateTimeOffset CreationDateTime { get; private set; }
    private EmployeeCategory()
    {
        
    }
    public EmployeeCategory(Guid id, string employeeCategoryCode, string employeeCategoryName) : base(id)
    {
        Code = employeeCategoryCode;
        Name = employeeCategoryName;
        CreationDateTime = DateTimeOffset.UtcNow;
    }
}

