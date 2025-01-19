using ams.domain.Employees;

namespace ams.infrastructure.Repositories
{
    internal sealed class EmployeeRepository
        : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
