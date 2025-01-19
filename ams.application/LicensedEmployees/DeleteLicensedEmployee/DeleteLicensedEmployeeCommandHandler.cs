using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.LicensedEmployees;

namespace ams.application.LicensedEmployees.DeleteLicensedEmployee;
internal sealed class DeleteLicensedEmployeeCommandHandler
    : ICommandHandler<DeleteLicensedEmployeeCommand, Guid>
{
    private readonly ILicensedEmployeeRepository _licensedEmployeeRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteLicensedEmployeeCommandHandler(ILicensedEmployeeRepository licensedEmployeeRepository, IUnitOfWork unitOfWork)
    {
        _licensedEmployeeRepository = licensedEmployeeRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        DeleteLicensedEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var licensedEmployee = await _licensedEmployeeRepository.GetByIdAsync(request.LicensedEmployeeId, cancellationToken);
        if (licensedEmployee == null)
            return Guid.Empty;
        
        _licensedEmployeeRepository.Remove(licensedEmployee);
        await _unitOfWork.SaveChangesAsync();

        return licensedEmployee.Id;
    }
}

