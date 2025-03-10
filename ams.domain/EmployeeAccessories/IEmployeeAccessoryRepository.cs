﻿
namespace ams.domain.EmployeeAccessories;
public interface IEmployeeAccessoryRepository
{
    void Add(EmployeeAccessory employeeAccessory);
   // Task<List<EmployeeAccessory>> GetAllAsync(Guid employeeId);
    Task<EmployeeAccessory> GetByIdAsync(Guid employeeAccessoryId, CancellationToken cancellationToken = default);
    void Remove(EmployeeAccessory employeeAccessory);
}

