using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.Employees;
using ams.domain.Sims;

namespace ams.application.Sims.DeleteSim;

public sealed class DeleteSimCommandHandler
    : ICommandHandler<DeleteSimCommand, Guid>
{
    private readonly ISimRepository _simRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteSimCommandHandler(ISimRepository simRepository, IUnitOfWork unitOfWork)
    {
        _simRepository = simRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(DeleteSimCommand request, CancellationToken cancellationToken)
    {
        var sim = await _simRepository.GetByIdAsync(request.SimId, cancellationToken);
        if (sim == null)
            return Guid.Empty;
        _simRepository.Remove(sim);
        await _unitOfWork.SaveChangesAsync();
        return sim.Id;
    }
}
