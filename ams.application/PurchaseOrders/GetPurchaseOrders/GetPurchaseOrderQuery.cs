using ams.application.Abstractions.Messaging;
using ams.application.Models;

namespace ams.application.PurchaseOrders.GetPurchaseOrders;

public sealed record GetPurchaseOrdersQuery(
    int pageIndex,
    int pageSize,
    string? searchQuery = null)
    : IQuery<PaginatedResponse<PurchaseOrderResponse>>
{ }
