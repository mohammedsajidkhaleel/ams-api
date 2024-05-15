using ams.domain.Abstractions;

namespace ams.domain.Licenses.Events;
public sealed record class LicenseUpdatedDomainEvent(Guid licenseId)
    : IDomainEvent;