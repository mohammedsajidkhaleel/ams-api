namespace ams.application.LicensedEmployees.GetLicencedEmployees;
public sealed class LicensedEmployeeResponse
{
    public Guid Id { get; init; }
    public Guid LicenseId { get; init; }
    public Guid EmployeeId { get; init; }
    public string LicenseName { get; init; }
    public string EmployeeCode { get; init; }
    public string EmployeeName { get; init; }
    public DateTimeOffset CreationDateTime { get; init; }
}