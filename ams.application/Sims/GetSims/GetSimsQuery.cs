using ams.application.Abstractions.Messaging;
using ams.application.Models;

namespace ams.application.Sims.GetSims;

public sealed record GetSimsQuery(string searchQuery,int pageIndex,int pageSize)
    : IQuery<PaginatedResponse<SimsResponse>>
{ }
