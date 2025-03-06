namespace ams.application.Assets.GetAssetsByItem;

public sealed class AssetsByItemReponse
{
    public string PoNumber { get; set; }
    public string ItemName { get; set; }
    public long Total { get; set; }
    public long Available { get; set; }
    public long Assigned { get; set; }
    public long Maintenance { get; set; }
    public long Dicommissioned { get; set; }
}
