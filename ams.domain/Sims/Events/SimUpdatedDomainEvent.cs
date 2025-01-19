
using ams.domain.Abstractions;

namespace ams.domain.Sims.Events;

public sealed record SimUpdatedDomainEvent(Guid simId)
    : IDomainEvent;
