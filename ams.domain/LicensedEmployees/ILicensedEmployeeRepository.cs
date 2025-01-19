
namespace ams.domain.LicensedEmployees;
public interface ILicensedEmployeeRepository
{
    void Add(LicensedEmployee licensedEmployee);
    Task<LicensedEmployee> GetByIdAsync(Guid licensedEmployeeId, CancellationToken cancellationToken);
    void Remove(LicensedEmployee licensedEmployee);
}

