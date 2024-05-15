using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.Assets;
using ams.domain.Shared;

namespace ams.application.Assets.EditAsset;
internal sealed class EditAssetCommandHandler
    : ICommandHandler<EditAssetCommand, Guid>
{
    private readonly IAssetRepository _assetRepository;
    private readonly IUnitOfWork _unitOfWork;
    public EditAssetCommandHandler(IAssetRepository assetRepository, IUnitOfWork unitOfWork)
    {
        _assetRepository = assetRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        EditAssetCommand request,
        CancellationToken cancellationToken)
    {
        var asset = await _assetRepository.GetByIdAsync(request.AssetId);
        if (asset != null)
        {
            Asset.EditAsset(asset,
                 new AssetCode(request.AssetCode),
            new AssetName(request.AssetName),
            new SerialNumber(request.SerialNumber),
            request.AssignedTo,
            request.ProjectId,
            new AssetDescription(request.AssetDescription),
            request.ItemId,
            new PONumber(request.PONumber));
        }
        await _unitOfWork.SaveChangesAsync();
        return asset.Id;
    }
}

