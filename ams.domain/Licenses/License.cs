using ams.domain.Abstractions;
using ams.domain.Licenses.Events;
using ams.domain.Projects;
using ams.domain.Shared;

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
    public Guid? ProjectId { get; set; }
    public PONumber? PONumber { get; set; }
    private License()
    {

    }
    private License(Guid id,
        LicenseName name,
        DateOnly? purchaseDate,
        DateOnly? expirationDate,
        LicenseDescription? description,
        Guid? createdBy,
        int totalLicenses,
        Guid? projectId,
        PONumber? poNumber) : base(id)
    {
        Id = id;
        Name = name;
        PurchasedDate = purchaseDate;
        ExpirationDate = expirationDate;
        Description = description;
        CreatedBy = createdBy;
        TotalLicenses = totalLicenses;
        CreationDateTime = DateTimeOffset.UtcNow;
        ProjectId = projectId;
        PONumber = poNumber;
    }

    public static License CreateLicense(LicenseName name,
           DateOnly? purchaseDate,
        DateOnly? expirationDate,
        LicenseDescription? description,
        Guid? createdBy,
        int totalLicenses,
        Guid? projectId,
        PONumber poNumber)
    {
        var license = new License(Guid.NewGuid(),
            name,
            purchaseDate,
            expirationDate,
            description,
            createdBy,
            totalLicenses,
            projectId,
            poNumber);
        license.RaiseDomainEvent(new LicenseCreatedDomainEvent(license.Id));
        return license;
    }

    public static License EditLicense(License license, LicenseName name,
       DateOnly? purchaseDate,
    DateOnly? expirationDate,
    LicenseDescription? description,
    int totalLicenses,
    Guid? projectId,
    PONumber poNumber)
    {
        license.Name = name;
        license.PurchasedDate = purchaseDate;
        license.ExpirationDate = expirationDate;
        license.Description = description;
        license.TotalLicenses = totalLicenses;
        license.ProjectId = projectId;
        license.PONumber = poNumber;
        license.RaiseDomainEvent(new LicenseUpdatedDomainEvent(license.Id));
        return license;
    }
}

