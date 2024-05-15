using ams.domain.Assets;

namespace ams.domain.Licenses;
public interface ILicenseRepository
{
    void Add(License license);
    Task<License?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Remove(License license);
}

