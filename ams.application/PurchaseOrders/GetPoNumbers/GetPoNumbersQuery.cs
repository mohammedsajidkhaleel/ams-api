using ams.application.Abstractions.Messaging;
using ams.application.Models;

namespace ams.application.PurchaseOrders.GetPoNumbers;
public sealed record GetPoNumbersQuery(int pageIndex = 0, int pageSize = 10, string poNumber = "")
: IQuery<PaginatedResponse<PoNumbersReponse>>
{
}

