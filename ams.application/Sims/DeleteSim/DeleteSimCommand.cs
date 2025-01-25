using ams.application.Abstractions.Messaging;

namespace ams.application.Sims.DeleteSim;

public sealed record DeleteSimCommand(Guid SimId)
    :ICommand<Guid>;
