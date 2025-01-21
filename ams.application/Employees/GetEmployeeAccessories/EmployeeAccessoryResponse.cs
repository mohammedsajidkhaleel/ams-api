namespace ams.application.Employees.GetEmployeeAccessories;

public sealed class EmployeeAccessoryResponse
{
    public Guid Id { get; set; }
    public Guid AccessoryId { get; set; }
    public string AccessoryName { get; set; }
    public DateTimeOffset CreationDateTime { get; set; }
}
