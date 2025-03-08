using ams.application.Employees.GetAccessories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Accessories;

[Authorize]
[ApiController]
[Route("api/accessories")]
public class AccessoriesController : ControllerBase
{
    private ISender _sender;
    public AccessoriesController(ISender sender)
    {
        _sender = sender;
    }
    [HttpGet]
    public async Task<IActionResult> GetAccessories(
       CancellationToken cancellationToken = default)
    {
        var accessories = new GetAccessoriesQuery();
        var result = await _sender.Send(accessories, cancellationToken);
        return Ok(result.Value);
    }
}
