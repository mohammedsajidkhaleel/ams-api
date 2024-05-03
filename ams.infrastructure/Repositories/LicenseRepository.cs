using ams.domain.Licenses;

namespace ams.infrastructure.Repositories;
internal sealed class LicenseRepository
    : Repository<License>, ILicenseRepository
{
    public LicenseRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {

    }
}
