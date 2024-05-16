
namespace ams.domain.LicensedAssets;
public interface ILicensedAssetRepository
{
    void Add(LicensedAsset licensedAsset);
    Task<LicensedAsset> GetByIdAsync(Guid licensedAssetId, CancellationToken cancellationToken);
    void Remove(LicensedAsset licensedAsset);
}

