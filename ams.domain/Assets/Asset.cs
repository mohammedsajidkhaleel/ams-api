using ams.domain.Abstractions;
using ams.domain.Assets.Events;
using ams.domain.Shared;

namespace ams.domain.Assets;
public sealed class Asset : Entity
{
    public AssetCode Code { get; private set; }
    public AssetName Name { get; private set; }
    public SerialNumber SerialNumber { get; private set; }
    public Guid? AssignedTo { get; private set; }
    public Guid? ProjectId { get; private set; }
    public DateTimeOffset CreationDateTime { get; private set; }
    public AssetStatus Status { get; private set; }
    public AssetDescription Description { get; private set; }
    public Guid? ItemId { get; private set; }
    public PONumber PONumber { get; private set; }
    private Asset()
    {

    }
    private Asset(Guid id,
        AssetCode assetCode,
        AssetName assetName,
        SerialNumber serialNumber,
        Guid? assignedTo,
        Guid? projectId,
        AssetDescription assetDescription,
        Guid? itemId,
        PONumber pONumber,
        AssetStatus status
        ) : base(id)
    {
        Name = assetName;
        Code = assetCode;
        SerialNumber = serialNumber;
        AssignedTo = assignedTo;
        ProjectId = projectId;
        CreationDateTime = DateTimeOffset.UtcNow;
        Status = status;
        Description = assetDescription;
        ItemId = itemId;
        PONumber = pONumber;
    }

    public static Asset CreateAsset(
        AssetCode assetCode,
        AssetName assetName,
        SerialNumber serialNumber,
        Guid? assignedTo,
        Guid? projectId,
        AssetDescription assetDescription,
        Guid? itemId,
        PONumber pONumber,
        AssetStatus assetStatus)
    {
        var asset = new Asset(Guid.NewGuid(), assetCode, assetName, serialNumber, assignedTo, projectId, assetDescription, itemId, pONumber, assetStatus);
        asset.RaiseDomainEvent(new AssetCreatedDomainEvent(asset.Id));
        return asset;
    }
    public static Asset EditAsset(Asset asset,
        AssetCode assetCode,
        AssetName assetName,
        SerialNumber serialNumber,
        Guid? assignedTo,
        Guid? projectId,
        AssetDescription assetDescription,
        Guid? itemId,
        PONumber pONumber
        )
    {
        asset.Code = assetCode;
        asset.Name = assetName;
        asset.SerialNumber = serialNumber;
        asset.AssignedTo = assignedTo;
        asset.ProjectId = projectId;
        asset.Description = assetDescription;
        asset.ItemId = itemId;
        asset.PONumber = pONumber;
        return asset;
    }
    public static Asset DeleteAsset(Asset asset)
    {
        asset.IsDeleted = true;
        return asset;
    }
}
