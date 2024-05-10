using ams.api.Controllers.Employees;
using ams.application.Assets.CreateAsset;
using ams.application.Assets.GetAssets;
using ams.application.Employees.CreateEmployee;
using ams.application.Employees.GetEmployees;
using ams.domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Assets;

[Authorize]
[ApiController]
[Route("api/[controller]")]

public class AssetsController : ControllerBase
{
    ISender _sender;
    public AssetsController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsset(AssetRequest model,
               CancellationToken cancellationToken)
    {
        var command = new CreateAssetCommand(
         model.Code,
         model.Name,
         model.SerialNumber,
         model?.AssignedTo,
         model?.ProjectId,
         model?.Description ?? "",
         model?.ItemId,
         model?.PONumber ?? ""
            );
        Result<Guid> result = await _sender.Send(command, cancellationToken);
        return CreatedAtAction(nameof(CreateAsset),
            new { id = result.Value }, result.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAssets(
        int pageIndex = 0,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetAssetsQuery(pageIndex, pageSize);
        var assets = await _sender.Send(query);
        return Ok(assets);
    }
}
