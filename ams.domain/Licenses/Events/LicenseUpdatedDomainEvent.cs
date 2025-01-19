using ams.domain.Abstractions;

namespace ams.domain.Licenses.Events;
public sealed record LicenseUpdatedDomainEvent(Guid licenseId)
    : IDomainEvent;