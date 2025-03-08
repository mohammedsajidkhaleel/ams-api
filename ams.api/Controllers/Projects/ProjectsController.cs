using ams.application.GetProjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Items;

[Authorize]
[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private ISender _sender;
    public ProjectsController(ISender sender)
    {
        _sender = sender;
    }
    [HttpGet]
    public async Task<IActionResult> GetProjects(
        int pageIndex = 0,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var projectQuery = new GetProjectsQuery(pageIndex, pageSize);
        var result = await _sender.Send(projectQuery, cancellationToken);
        return Ok(result);
    }
}
