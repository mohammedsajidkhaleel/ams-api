using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.Assets;
using ams.domain.Sims;

namespace ams.application.Sims.CreateSim;

public sealed class CreateSimCommandHandler
    : ICommandHandler<CreateSimCommand, Guid>
{
    private readonly ISimRepository _simRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateSimCommandHandler(ISimRepository simRepository, IUnitOfWork unitOfWork)
    {
        _simRepository = simRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        CreateSimCommand request,
        CancellationToken cancellationToken)
    {
        var sim = Sim.CreateSim(
            new ServiceAccount(request.serviceAccount),
            new ServiceNumber(request.serviceNumber),
            new SimCardNumber(request.simCardNumber),
            new Imei1(request.imei1),
            request.createdBy,
            request.assignedTo
            );
        _simRepository.Add(sim);
        await _unitOfWork.SaveChangesAsync();
        return sim.Id;
    }
}
