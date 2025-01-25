using ams.application.Abstractions.Messaging;

namespace ams.application.Sims.EditSim;

public sealed record EditSimCommand
    (Guid Id,
     string ServiceAccount,
     string ServiceNumber,
     string SimCardNumber,
     string Imei1,
     Guid? AssignedTo,
     Guid? AssignedPlan,
     Guid? UpdatedBy
    )
    : ICommand<Guid>;
