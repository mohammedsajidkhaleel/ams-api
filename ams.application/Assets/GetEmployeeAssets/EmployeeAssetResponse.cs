namespace ams.application.Assets.GetEmployeeAssets;
public sealed class EmployeeAssetResponse
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string SerialNumber { get; set; }
    public Guid? AssignedTo { get; set; }
    public Guid? ProjectId { get; set; }
    public string EmployeeName { get; set; }
    public string ProjectName { get; set; }
    public DateTimeOffset CreationDateTime { get; set; }
    public string ItemName { get; set; }
    public string PONumber { get; set; }
    public string Status { get; set; }
}
