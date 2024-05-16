using ams.domain.Abstractions;

namespace ams.domain.LicensedAssets;

public sealed class LicensedAsset : Entity
{
    public Guid LicenseId { get; set; }
    public Guid AssetId { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTimeOffset CreationDateTime { get; set; }

    private LicensedAsset() { }
    private LicensedAsset(Guid id,
        Guid licenseId,
        Guid assetId,
        Guid? createdBy)
    {
        Id = id;
        LicenseId = licenseId;
        AssetId = assetId;
        CreatedBy = createdBy;
        CreationDateTime = DateTimeOffset.UtcNow;
    }

    public static LicensedAsset CreateLicensedAsset(
        Guid licenseId,
        Guid assetId,
        Guid? createdBy)
    {
        var licensedAsset = new LicensedAsset(
            Guid.NewGuid(),
            licenseId,
            assetId,
            createdBy);
        return licensedAsset;
    }
}
