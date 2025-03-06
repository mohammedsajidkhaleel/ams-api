using ams.application.Abstractions.Messaging;
using ams.application.Models;

namespace ams.application.Assets.GetAssetsByItem;
public sealed record GetAssetsByItemQuery(int pageIndex = 0, int pageSize = 10, string poNumber = "")
: IQuery<PaginatedResponse<AssetsByItemReponse>>
{
}

