using ams.application.Abstractions.Messaging;

namespace ams.application.Assets.GetEmployeeAssets;
public sealed record GetEmployeeAssetsQuery(Guid EmployeeId)
: IQuery<IReadOnlyList<EmployeeAssetResponse>>
{
}

