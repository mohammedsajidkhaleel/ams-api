using ams.domain.Abstractions;
namespace ams.domain.Assets.Events;
public sealed record AssetUpdatedDomainEvent(Guid assetId) : IDomainEvent;

