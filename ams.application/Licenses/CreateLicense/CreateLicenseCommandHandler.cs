using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.Licenses;

namespace ams.application.Licenses.CreateLicense;
public sealed class CreateLicenseCommandHandler
    : ICommandHandler<CreateLicenseCommand, Guid>
{
    private readonly ILicenseRepository _licenseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLicenseCommandHandler(ILicenseRepository licenseRepository, IUnitOfWork unitOfWork)
    {
        _licenseRepository = licenseRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(CreateLicenseCommand request, CancellationToken cancellationToken)
    {
        var license = License.CreateLicense(new LicenseName(request.LicenseName),
            request.PurchasedDate,
            request.ExpirationDate,
            new LicenseDescription(request.Description),
            request.CreatedBy,
            request.TotalLicenses
            );
        _licenseRepository.Add(license);
        await _unitOfWork.SaveChangesAsync();
        return license.Id;
    }
}
