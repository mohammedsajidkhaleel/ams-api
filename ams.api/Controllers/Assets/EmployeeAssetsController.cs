using ams.application.Assets.GetEmployeeAssets;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Assets
{
    [Route("api/employeeassets")]
    [ApiController]
    public class EmployeeAssetsController : ControllerBase
    {
        ISender _sender;
        public EmployeeAssetsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeAssets(Guid employeeId, CancellationToken cancellationToken = default)
        {
            var query = new GetEmployeeAssetsQuery(employeeId);
            var assets = await _sender.Send(query, cancellationToken);
            return Ok(assets);
        }
    }
}
