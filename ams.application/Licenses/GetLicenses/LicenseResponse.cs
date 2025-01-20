namespace ams.application.Licenses.GetLicenses;
public sealed class LicenseResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; set; }
    public string PurchasedDate { get; set; }
    public string ExpirationDate { get; set; }
    public string TotalLicenses { get; set; }
    public string CreationDateTime { get; set; }
    public string PoNumber { get; set; }
}