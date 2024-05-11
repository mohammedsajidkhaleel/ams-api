using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Assets.DeleteAsset;
using ams.domain.Abstractions;
using ams.domain.Assets;

namespace ams.application.Assets.CreateAsset;
internal sealed class DeleteAssetCommandHandler
    : ICommandHandler<DeleteAssetCommand, Guid>
{
    private readonly IAssetRepository _assetRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteAssetCommandHandler(IAssetRepository assetRepository, IUnitOfWork unitOfWork)
    {
        _assetRepository = assetRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        DeleteAssetCommand request,
        CancellationToken cancellationToken)
    {
       var asset = await _assetRepository.GetByIdAsync(request.AssetId);
        if(asset != null) {
            _assetRepository.Remove(asset);
            await _unitOfWork.SaveChangesAsync();
        }
        return null;
    }
}

