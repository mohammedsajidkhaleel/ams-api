using ams.application.Sims.GetMobilePlan;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Sims;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MobilePlansController : ControllerBase
{
    ISender _sender;
    public MobilePlansController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetMobilePlans(
        CancellationToken cancellationToken)
    {
        var query = new GetMobilePlanQuery();
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result);
    }
}
