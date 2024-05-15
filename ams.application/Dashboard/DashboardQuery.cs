using ams.application.Abstractions.Messaging;

namespace ams.application.Dashboard;
public sealed record DashboardQuery()
    : IQuery<DashboardResponse>;
