using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.Licenses;
using ams.domain.Shared;

namespace ams.application.Licenses.EditLicense;
public sealed class EditLicenseCommandHandler
    : ICommandHandler<EditLicenseCommand, Guid>
{
    private readonly ILicenseRepository _licenseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EditLicenseCommandHandler(ILicenseRepository licenseRepository, IUnitOfWork unitOfWork)
    {
        _licenseRepository = licenseRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(EditLicenseCommand request, CancellationToken cancellationToken)
    {
        var license = License.CreateLicense(new LicenseName(request.LicenseName),
            request.PurchasedDate,
            request.ExpirationDate,
            new LicenseDescription(request.Description),
            request.CreatedBy,
            request.TotalLicenses,
            request.ProjectId,
            new PONumber(request?.PONumber)
            );
        _licenseRepository.Add(license);
        await _unitOfWork.SaveChangesAsync();
        return license.Id;
    }
}
