using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.Assets;
using ams.domain.Shared;

namespace ams.application.Assets.CreateAsset;
internal sealed class CreateAssetCommandHandler
    : ICommandHandler<CreateAssetCommand, Guid>
{
    private readonly IAssetRepository _assetRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateAssetCommandHandler(IAssetRepository assetRepository, IUnitOfWork unitOfWork)
    {
        _assetRepository = assetRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        CreateAssetCommand request,
        CancellationToken cancellationToken)
    {
        var asset = Asset.CreateAsset(
            new AssetCode(request.AssetCode),
            new AssetName(request.AssetName),
            new SerialNumber(request.SerialNumber),
            request.AssignedTo,
            request.ProjectId,
            new AssetDescription(request.AssetDescription),
            request.ItemId,
            new PONumber(request.PONumber),
            request?.AssignedTo == null ? AssetStatus.Issued : AssetStatus.InStock
            );
        _assetRepository.Add(asset);
        await _unitOfWork.SaveChangesAsync();
        return asset.Id;
    }
}

