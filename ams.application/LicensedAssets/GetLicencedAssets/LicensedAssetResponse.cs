namespace ams.application.LicensedAssets.GetLicencedAssets;
public sealed class LicensedAssetResponse
{
    public Guid Id { get; init; }
    public Guid LicenseId { get; init; }
    public Guid AssetId { get; init; }
    public string LicenseName { get; init; }
    public string ItemName { get; init; }
    public string AssetCode { get; init; }
    public string AssetName { get; init; }
    public string AssignedTo { get; set; }
    public DateTimeOffset CreationDateTime { get; init; }
}