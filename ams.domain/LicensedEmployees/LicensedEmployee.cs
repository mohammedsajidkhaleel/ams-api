using ams.domain.Abstractions;

namespace ams.domain.LicensedEmployees;

public sealed class LicensedEmployee : Entity
{
    public Guid LicenseId { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTimeOffset CreationDateTime { get; set; }

    private LicensedEmployee() { }
    private LicensedEmployee(Guid id,
        Guid licenseId,
        Guid employeeId,
        Guid? createdBy)
    {
        Id = id;
        LicenseId = licenseId;
        EmployeeId = employeeId;
        CreatedBy = createdBy;
        CreationDateTime = DateTimeOffset.UtcNow;
    }

    public static LicensedEmployee CreateLicensedEmployee(
        Guid licenseId,
        Guid employeeId,
        Guid? createdBy)
    {
        var licenseEmployee = new LicensedEmployee(
            Guid.NewGuid(),
            licenseId,
            employeeId,
            createdBy);
        return licenseEmployee;
    }
}
