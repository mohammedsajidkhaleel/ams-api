using ams.domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
