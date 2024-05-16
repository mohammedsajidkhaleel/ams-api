using ams.application.Abstractions.Messaging;
using ams.application.Models;

namespace ams.application.LicensedAssets.GetLicencedAssets;

public sealed record GetLicensedAssetQuery(Guid licenseId,int pageIndex, int pageSize)
    : IQuery<PaginatedResponse<LicensedAssetResponse>>
{
}
