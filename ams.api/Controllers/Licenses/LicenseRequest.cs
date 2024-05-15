namespace ams.api.Controllers.Licenses;

public record LicenseRequest(
    string Name,
    string? Description,
    DateOnly? PurchasedDate,
    DateOnly? ExpirationDate,
    int? TotalLicenses,
    Guid? projectId,
    string? poNumber
    );
