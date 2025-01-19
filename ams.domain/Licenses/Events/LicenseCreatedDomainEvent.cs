using ams.domain.Abstractions;

namespace ams.domain.Licenses.Events;
public sealed record LicenseCreatedDomainEvent(Guid licenseId)
    : IDomainEvent;