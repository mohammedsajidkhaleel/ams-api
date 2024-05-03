using ams.domain.Abstractions;
using ams.domain.Licenses.Events;

namespace ams.domain.Licenses;
public sealed class License : Entity
{
    public LicenseName Name { get; private set; }
    public DateOnly? PurchasedDate { get; set; }
    public DateOnly? ExpirationDate { get; set; }
    public LicenseDescription? Description { get; private set; }
    public Guid? CreatedBy { get; set; }
    public DateTimeOffset CreationDateTime { get; set; }
    public int TotalLicenses { get; set; }
    public bool IsDeleted { get; set; }
    private License()
    {
        
    }
    private License(Guid id,
        LicenseName name,
        DateOnly? purchaseDate,
        DateOnly? expirationDate,
        LicenseDescription? description,
        Guid? createdBy,
        int totalLicenses) : base(id)
    {
        Id = id;
        Name = name;
        PurchasedDate = purchaseDate;
        ExpirationDate = expirationDate;
        Description = description;
        CreatedBy = createdBy;
        TotalLicenses = totalLicenses;
        CreationDateTime = DateTimeOffset.UtcNow;
    }

    public static License CreateLicense(LicenseName name,
           DateOnly? purchaseDate,
        DateOnly? expirationDate,
        LicenseDescription? description,
        Guid? createdBy,
        int totalLicenses)
    {
        var license = new License(Guid.NewGuid(),
            name,
            purchaseDate,
            expirationDate,
            description,
            createdBy,
            totalLicenses);
        license.RaiseDomainEvent(new LicenseCreatedDomainEvent(license.Id));
        return license;
    }
}

