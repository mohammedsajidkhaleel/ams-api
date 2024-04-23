using ams.application.Abstractions.Messaging;

namespace ams.application.Employees.GetSponsors;
public sealed record GetSponsorQuery()
    : IQuery<IReadOnlyList<SponsorResponse>>;
