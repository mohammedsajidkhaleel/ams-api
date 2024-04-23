using ams.application.Abstractions.Messaging;
namespace ams.application.GetProjects;
public sealed record GetProjectsQuery
    : IQuery<IReadOnlyList<ProjectsResponse>>
{
}

