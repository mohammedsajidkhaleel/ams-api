using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.LicensedAssets;

namespace ams.application.LicensedAssets.DeleteLicensedAsset;
internal sealed class DeleteLicensedAssetCommandHandler
    : ICommandHandler<DeleteLicensedAssetCommand, Guid>
{
    private readonly ILicensedAssetRepository _licensedAssetRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteLicensedAssetCommandHandler(ILicensedAssetRepository licensedAssetRepository, IUnitOfWork unitOfWork)
    {
        _licensedAssetRepository = licensedAssetRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        DeleteLicensedAssetCommand request,
        CancellationToken cancellationToken)
    {
       var licensedAsset = await _licensedAssetRepository.GetByIdAsync(request.LicensedAssetId,cancellationToken);
        if(licensedAsset != null) {
            _licensedAssetRepository.Remove(licensedAsset);
            await _unitOfWork.SaveChangesAsync();
        }
        return null;
    }
}

