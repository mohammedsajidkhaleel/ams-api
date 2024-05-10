using ams.application.Licenses.CreateLicense;
using ams.application.Licenses.GetLicenses;
using ams.domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Licenses;

[Authorize]
[ApiController]
[Route("api/licenses")]
public class LicenseController : ControllerBase
{
    private ISender _sender;
    public LicenseController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateLicense(
        LicenseRequest model,
        CancellationToken cancellationToken
        )
    {
        var command = new CreateLicenseCommand(
            model.Name,
            model.Description,
            model?.PurchasedDate,
            model?.ExpirationDate,
            null,
            model?.TotalLicenses ?? 0
            );
        Result<Guid> result = await _sender.Send(command,
            cancellationToken);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetLicenses(CancellationToken cancellationToken)
    {
        var query = new GetLicenseQuery();
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result);
    }
}
