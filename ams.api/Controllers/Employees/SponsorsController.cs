using ams.application.Employees.GetSponsors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Employees;

[Authorize]
[ApiController]
[Route("api/sponsors")]

public class SponsorsController : ControllerBase
{
    ISender _sender;
    public SponsorsController(ISender sender)
    {
        _sender = sender;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllSponsors(CancellationToken cancellationToken = default)
    {
        var query = new GetSponsorQuery();
        var sponsors = await _sender.Send(query, cancellationToken);
        return Ok(sponsors);
    }
}
