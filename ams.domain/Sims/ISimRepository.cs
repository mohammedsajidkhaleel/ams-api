namespace ams.domain.Sims;

public interface ISimRepository
{
    void Add(Sim sim);
    Task<Sim?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Remove(Sim sim);

}
