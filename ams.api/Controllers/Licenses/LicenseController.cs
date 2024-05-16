using ams.application.Licenses.CreateLicense;
using ams.application.Licenses.DeleteLicense;
using ams.application.Licenses.EditLicense;
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
            model?.TotalLicenses ?? 0,
            model?.projectId,
            model?.poNumber
            );
        Result<Guid> result = await _sender.Send(command,
            cancellationToken);
        return Ok(result);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> EditLicense(
        [FromRoute] Guid id,
        [FromBody] LicenseRequest model,
        CancellationToken cancellationToken
        )
    {
        var command = new EditLicenseCommand(
            id,
            model.Name,
            model.Description,
            model?.PurchasedDate,
            model?.ExpirationDate,
            null,
            model?.TotalLicenses ?? 0,
            model?.projectId,
            model?.poNumber
            );
        var result = await _sender.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetLicenses(CancellationToken cancellationToken)
    {
        var query = new GetLicenseQuery();
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteLicense(Guid id, CancellationToken cancellationToken)
    {
        var query = new DeleteLicenseCommand(id);
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result);
    }
}
