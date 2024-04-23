
using ams.domain.Assets;

namespace ams.infrastructure.Repositories;
internal sealed class AssetRepository
    : Repository<Asset>, IAssetRepository
{
    public AssetRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
}

