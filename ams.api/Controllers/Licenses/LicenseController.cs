using ams.api.Extensions;
using ams.application.LicensedAssets.CreateLicensedAsset;
using ams.application.LicensedAssets.DeleteLicensedAsset;
using ams.application.LicensedAssets.GetLicencedAssets;
using ams.application.LicensedEmployees.CreateLicensedEmployee;
using ams.application.LicensedEmployees.DeleteLicensedEmployee;
using ams.application.LicensedEmployees.GetLicencedEmployees;
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

    [HttpGet("{id:Guid}/assets")]
    public async Task<IActionResult> GetLicensedAssets([FromRoute] Guid id, [FromQuery] int? pageIndex = 0, [FromQuery] int? pageSize = 10)
    {
        var query = new GetLicensedAssetQuery(id, pageIndex.Value, pageSize.Value);
        var result = await _sender.Send(query);
        return Ok(result);
    }

    [HttpPost("{id:Guid}/assets")]
    public async Task<IActionResult> AssignLicenseToAsset([FromRoute] Guid id, [FromBody] LicensedAssetRequest model, CancellationToken cancellationToken)
    {
        var query = new CreateLicensedAssetCommand(id, model.AssetId, HttpContext.User.GetLoggedInUser());
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("assets/{id:Guid}")]
    public async Task<IActionResult> RemoveLicenseFromAsset(Guid id, CancellationToken cancellationToken)
    {
        var query = new DeleteLicensedAssetCommand(id);
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:Guid}/employees")]
    public async Task<IActionResult> GetLicensedEmployees([FromRoute] Guid id, [FromQuery] int? pageIndex = 0, [FromQuery] int? pageSize = 50)
    {
        var query = new GetLicensedEmployeeQuery(id, pageIndex ?? 0, pageSize ?? 50);
        var result = await _sender.Send(query);
        return Ok(result);
    }

    [HttpPost("{id:Guid}/employees")]
    public async Task<IActionResult> AssignLicenseToEmployee([FromRoute] Guid id, [FromBody] LicensedEmployeeRequest model, CancellationToken cancellationToken)
    {
        var query = new CreateLicensedEmployeeCommand(id, model.EmployeeId, HttpContext.User.GetLoggedInUser());
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("employees/{id:Guid}")]
    public async Task<IActionResult> RemoveLicenseFromEmployee(Guid id, CancellationToken cancellationToken)
    {
        var query = new DeleteLicensedEmployeeCommand(id);
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result);
    }
}
