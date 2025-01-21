using ams.application.Abstractions.Messaging;
using ams.application.LicensedEmployees.CreateEmployeeAccessory;
using ams.domain.Abstractions;
using ams.domain.EmployeeAccessories;

namespace ams.application.Employees.CreateEmployeeAccessory;
public sealed class CreateEmployeeAccessoryCommandHandler
    : ICommandHandler<CreateEmployeeAccessoryCommand, Guid>
{
    private readonly IEmployeeAccessoryRepository _employeeAccessoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeAccessoryCommandHandler(IUnitOfWork unitOfWork, IEmployeeAccessoryRepository employeeAccessoryRepository)
    {
        _unitOfWork = unitOfWork;
        _employeeAccessoryRepository = employeeAccessoryRepository;
    }
    public async Task<Result<Guid>> Handle(CreateEmployeeAccessoryCommand request, CancellationToken cancellationToken)
    {
        var employeeAccessory = EmployeeAccessory.CreateEmployeeAccessory(request.employeeId, request.accesoryId, request.createdBy);
        _employeeAccessoryRepository.Add(employeeAccessory);
        await _unitOfWork.SaveChangesAsync();
        return employeeAccessory.Id;
    }
}
