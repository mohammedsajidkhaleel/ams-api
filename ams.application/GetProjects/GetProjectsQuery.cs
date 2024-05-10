using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Models;
namespace ams.application.GetProjects;
public sealed record GetProjectsQuery(int pageIndex = 0, int pageSize = 10)
    : IQuery<PaginatedResponse<ProjectsResponse>>
{
}

