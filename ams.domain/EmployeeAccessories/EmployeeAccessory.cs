using ams.domain.Abstractions;

namespace ams.domain.EmployeeAccessories;

public sealed class EmployeeAccessory : Entity
{
    public Guid EmployeeId { get; set; }
    public Guid AccessoryId { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTimeOffset CreationDateTime { get; set; }
    private EmployeeAccessory() { }
    private EmployeeAccessory(Guid id,
        Guid employeeId,
        Guid accessoryId,
        Guid? createdBy)
    {
        Id = id;
        EmployeeId = employeeId;
        AccessoryId = accessoryId;
        CreatedBy = createdBy;
        CreationDateTime = DateTimeOffset.UtcNow;
    }

    public static EmployeeAccessory CreateEmployeeAccessory(
        Guid employeeId,
        Guid accessoryId,
        Guid? createdBy)
    {
        var employeeAccessory = new EmployeeAccessory(
            Guid.NewGuid(),
            employeeId,
            accessoryId,
            createdBy);
        return employeeAccessory;
    }
}
