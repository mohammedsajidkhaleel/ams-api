using ams.domain.LicensedAssets;

namespace ams.infrastructure.Repositories;
internal sealed class LicensedAssetRepository
    : Repository<LicensedAsset>, ILicensedAssetRepository
{
    public LicensedAssetRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {

    }
}
