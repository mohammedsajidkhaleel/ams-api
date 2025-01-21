using ams.domain.EmployeeAccessories;

namespace ams.infrastructure.Repositories;
internal sealed class EmployeeAccessoryRepository
    : Repository<EmployeeAccessory>, IEmployeeAccessoryRepository
{
    public EmployeeAccessoryRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {

    }
}
