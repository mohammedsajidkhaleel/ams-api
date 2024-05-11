namespace ams.domain.Employees;
public interface IEmployeeRepository
{
    void Add(Employee employee);
    Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Remove(Employee employee);
}

