using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Models;

namespace ams.application.Assets.GetAssets;
public sealed record GetAssetsQuery(int pageIndex = 0, int pageSize = 10)
: IQuery<PaginatedResponse<AssetsResponse>>
{
}

