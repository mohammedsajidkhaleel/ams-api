
using ams.domain.Sims;

namespace ams.infrastructure.Repositories;
internal sealed class SimRepository
    : Repository<Sim>, ISimRepository
{
    public SimRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
}

