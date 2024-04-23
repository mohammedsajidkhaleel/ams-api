using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.domain.Employees
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
    }
}
