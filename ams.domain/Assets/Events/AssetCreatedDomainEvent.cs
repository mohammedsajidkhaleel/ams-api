using ams.domain.Abstractions;
namespace ams.domain.Assets.Events;
public sealed record AssetCreatedDomainEvent(Guid assetId) : IDomainEvent;

