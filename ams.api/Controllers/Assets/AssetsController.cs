using ams.application.Assets.CreateAsset;
using ams.application.Assets.DeleteAsset;
using ams.application.Assets.EditAsset;
using ams.application.Assets.GetAssets;
using ams.domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> EditAsset([FromRoute] Guid id,
        AssetRequest model,
        CancellationToken cancellationToken)
    {
        var command = new EditAssetCommand(
            id,
            model.Code,
         model.Name,
         model.SerialNumber,
         model?.AssignedTo,
         model?.ProjectId,
         model?.Description ?? "",
         model?.ItemId,
         model?.PONumber ?? "");
        Result<Guid> result = await _sender.Send(command, cancellationToken);
        return Ok(new { id = result.Value });
    }    
    
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteAsset([FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteAssetCommand(id);
        await _sender.Send(command, cancellationToken);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAssets(
        int pageIndex = 0,
        int pageSize = 10,
        string assetCode = "",
        CancellationToken cancellationToken = default)
    {
        var query = new GetAssetsQuery(pageIndex, pageSize, assetCode);
        var assets = await _sender.Send(query, cancellationToken);
        return Ok(assets);
    }


}
