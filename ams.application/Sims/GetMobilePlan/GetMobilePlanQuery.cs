using ams.application.Abstractions.Messaging;

namespace ams.application.Sims.GetMobilePlan;

public sealed record GetMobilePlanQuery
    :IQuery<IReadOnlyList<MobilePlanResponse>>;