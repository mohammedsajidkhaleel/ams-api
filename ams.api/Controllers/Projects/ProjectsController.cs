using ams.application.GetProjects;
using ams.application.Items.GetItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Items
{
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
            CancellationToken cancellationToken = default)
        {
            var projectQuery = new GetProjectsQuery();
            var result = await _sender.Send(projectQuery, cancellationToken);
            return Ok(result.Value);
        }
    }
}
