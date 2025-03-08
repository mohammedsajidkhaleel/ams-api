using ams.application.Employees.GetNationalities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Employees;

[Authorize]
[ApiController]
[Route("api/[controller]")]

public class NationalitiesController : ControllerBase
{
    ISender _sender;
    public NationalitiesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNationalities(CancellationToken cancellationToken = default)
    {
        var query = new GetNationalityQuery();
        var nationalities = await _sender.Send(query, cancellationToken);
        return Ok(nationalities);
    }
}
