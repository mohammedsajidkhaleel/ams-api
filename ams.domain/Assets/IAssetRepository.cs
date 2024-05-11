
namespace ams.domain.Assets;
public interface IAssetRepository
{
    void Add(Asset asset);
    Task<Asset?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Remove(Asset asset);
}

