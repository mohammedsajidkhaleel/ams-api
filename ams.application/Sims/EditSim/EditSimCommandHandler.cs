using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.Sims;

namespace ams.application.Sims.EditSim;

public sealed class EditSimCommandHandler
    : ICommandHandler<EditSimCommand, Guid>
{
    private readonly ISimRepository _simRepository;
    private readonly IUnitOfWork _unitOfWork;
    public EditSimCommandHandler(IUnitOfWork unitOfWork, ISimRepository simRepository)
    {
        _unitOfWork = unitOfWork;
        _simRepository = simRepository;
    }
    public async Task<Result<Guid>> Handle(EditSimCommand request, CancellationToken cancellationToken)
    {
        var sim = await _simRepository.GetByIdAsync(request.Id, cancellationToken);
        if (sim == null)
            return Guid.Empty;

        Sim.EditSim(sim,
            new ServiceAccount(request.ServiceAccount),
            new ServiceNumber(request.ServiceNumber),
            new SimCardNumber(request.SimCardNumber),
            new Imei1(request.Imei1),
            request.UpdatedBy,
            request.AssignedTo,
            request.AssignedPlan
           
        );

        await _unitOfWork.SaveChangesAsync();
        return sim.Id;
    }
}
