using ams.application.Abstractions.Messaging;
namespace ams.application.Employees.GetAccessories;

public sealed record GetAccessoriesQuery()
    : IQuery<IReadOnlyList<AccessoriesResponse>>;
