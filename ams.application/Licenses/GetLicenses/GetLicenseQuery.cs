using ams.application.Abstractions.Messaging;

namespace ams.application.Licenses.GetLicenses;

public sealed record GetLicenseQuery()
    :IQuery<IReadOnlyList<LicenseResponse>>
{
}
