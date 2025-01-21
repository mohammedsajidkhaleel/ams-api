using ams.application.Assets.GetAssets;
using ams.application.Employees.GetEmployeeAccessories;
using ams.application.LicensedEmployees.GetLicencedEmployees;

namespace ams.application.Employees.GetEmployee;
public sealed class EmployeeDetailResponse
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Doj { get; set; }
    public string Sponsor { get; set; }
    public string Department { get; set; }
    public string SubDepartment { get; set; }
    public string EmployeeCategory { get; set; }
    public string Nationality { get; set; }
    public string EmployeePosition { get; set; }
    public string Project { get; set; }
    public string IdNumber { get; set; }
    public string Location { get; set; }
    public List<LicensedEmployeeResponse> AssignedLicenses { get; set; } = new();
    public List<EmployeeAccessoryResponse> AssignedAccessories { get; set; } = new();
    public List<AssetsResponse> AssignedAssets { get; set; } = new();
}