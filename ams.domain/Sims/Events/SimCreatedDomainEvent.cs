using ams.domain.Abstractions;

namespace ams.domain.Sims.Events;

public sealed record SimCreatedDomainEvent(Guid simId)
    : IDomainEvent;
