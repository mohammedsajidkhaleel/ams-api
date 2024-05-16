using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.LicensedAssets.CreateLicensedAsset;
using ams.domain.Abstractions;
using ams.domain.LicensedAssets;
using ams.domain.Shared;

namespace ams.application.Licenses.CreateLicense;
public sealed class CreateLicensedAssetCommandHandler
    : ICommandHandler<CreateLicensedAssetCommand, Guid>
{
    private readonly ILicensedAssetRepository _licensedAssetRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLicensedAssetCommandHandler(ILicensedAssetRepository licensedAssetRepository, IUnitOfWork unitOfWork)
    {
        _licensedAssetRepository = licensedAssetRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(CreateLicensedAssetCommand request, CancellationToken cancellationToken)
    {
        var licensedAsset = LicensedAsset.CreateLicensedAsset(request.licenseId, request.assetId, request.createdBy);
        _licensedAssetRepository.Add(licensedAsset);
        await _unitOfWork.SaveChangesAsync();
        return licensedAsset.Id;
    }
}
