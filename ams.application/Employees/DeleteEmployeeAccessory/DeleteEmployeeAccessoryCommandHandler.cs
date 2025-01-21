using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.EmployeeAccessories;
using ams.domain.Employees;

namespace ams.application.Employees.DeleteEmployeeAccessory;

public sealed class DeleteEmployeeAccessoryCommandHandler
    : ICommandHandler<DeleteEmployeeAccessoryCommand, Guid>
{
    private readonly IEmployeeAccessoryRepository _employeeAccessoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteEmployeeAccessoryCommandHandler(IEmployeeAccessoryRepository employeeAccessoryRepository, IUnitOfWork unitOfWork)
    {
        _employeeAccessoryRepository = employeeAccessoryRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        DeleteEmployeeAccessoryCommand request,
        CancellationToken cancellationToken)
    {
        var employeeAccessory = await _employeeAccessoryRepository.GetByIdAsync(request.EmployeeAccessoryId, cancellationToken);
        if (employeeAccessory == null)
            return Guid.Empty;
        _employeeAccessoryRepository.Remove(employeeAccessory);
        await _unitOfWork.SaveChangesAsync();

        return employeeAccessory.Id;
    }
}
