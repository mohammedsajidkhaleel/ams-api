using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.Licenses;

namespace ams.application.Licenses.DeleteLicense;
internal sealed class DeleteLicenseCommandHandler
    : ICommandHandler<DeleteLicenseCommand, Guid>
{
    private readonly ILicenseRepository _licenseRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteLicenseCommandHandler(ILicenseRepository licenseRepository, IUnitOfWork unitOfWork)
    {
        _licenseRepository = licenseRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        DeleteLicenseCommand request,
        CancellationToken cancellationToken)
    {
       var license = await _licenseRepository.GetByIdAsync(request.LicenseId,cancellationToken);
        if(license != null) {
            _licenseRepository.Remove(license);
            await _unitOfWork.SaveChangesAsync();
        }
        return null;
    }
}

