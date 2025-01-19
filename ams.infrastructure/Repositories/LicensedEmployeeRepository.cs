using ams.domain.LicensedEmployees;

namespace ams.infrastructure.Repositories;
internal sealed class LicensedEmployeeRepository
    : Repository<LicensedEmployee>, ILicensedEmployeeRepository
{
    public LicensedEmployeeRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {

    }
}
