using ams.application.Abstractions.Messaging;

namespace ams.application.Assets.GetAssets;
public sealed record GetAssetsQuery()
: IQuery<IReadOnlyList<AssetsResponse>>
{
}

