using ams.application.Abstractions.Messaging;

namespace ams.application.Sims.CreateSim;

public sealed record CreateSimCommand(
    string serviceAccount,
    string serviceNumber,
    string simCardNumber,
    string imei1,
    Guid? createdBy,
    Guid? assignedTo,
    Guid? assignedPlan
    )
    : ICommand<Guid>;
