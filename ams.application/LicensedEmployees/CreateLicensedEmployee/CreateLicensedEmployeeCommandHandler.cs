using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.LicensedEmployees.CreateLicensedEmployee;
using ams.domain.Abstractions;
using ams.domain.LicensedEmployees;
using ams.domain.Shared;

namespace ams.application.Licenses.CreateLicense;
public sealed class CreateLicensedEmployeeCommandHandler
    : ICommandHandler<CreateLicensedEmployeeCommand, Guid>
{
    private readonly ILicensedEmployeeRepository _licensedEmployeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLicensedEmployeeCommandHandler(ILicensedEmployeeRepository licensedEmployeeRepository, IUnitOfWork unitOfWork)
    {
        _licensedEmployeeRepository = licensedEmployeeRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(CreateLicensedEmployeeCommand request, CancellationToken cancellationToken)
    {
        var licensedEmployee = LicensedEmployee.CreateLicensedEmployee(request.licenseId, request.employeeId, request.createdBy);
        _licensedEmployeeRepository.Add(licensedEmployee);
        await _unitOfWork.SaveChangesAsync();
        return licensedEmployee.Id;
    }
}
