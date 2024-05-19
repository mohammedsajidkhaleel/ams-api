using ams.application.ItemReceipts.ConvertToAsset;
using ams.application.ItemReceipts.CreateItemReceipt;
using ams.application.ItemReceipts.EditItemReceipt;
using ams.application.ItemReceipts.GetForAssetConvert;
using ams.application.ItemReceipts.GetItemReceipt;
using ams.application.ItemReceipts.GetItemReceipts;
using ams.domain.Abstractions;
using ams.domain.ItemReceipts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace ams.api.Controllers.ItemReceipts;

[Authorize]
[ApiController]
[Route("api/itemreceipts")]
public class ItemReceiptsController : ControllerBase
{
    private ISender _sender;
    public ItemReceiptsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemReceipt(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetItemReceiptQuery(id);
        Result<ItemReceiptResponse> result = await _sender.Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetItemReceipts(CancellationToken cancellationToken)
    {
        var query = new GetItemReceiptsQuery();
        var result = await _sender.Send(query,
            cancellationToken
            );
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateItemReceipt(
      ItemReceiptRequest model,
        CancellationToken cancellationToken
        )
    {
        List<ItemReceiptDetailRequest> details = new List<ItemReceiptDetailRequest>();
        foreach (var item in model.itemDetails)
        {
            details.Add(new ItemReceiptDetailRequest(item.itemId,
                item.quantity,
                item.description,
                item.serialNumbers
                ));
        }

        var command = new CreateItemReceiptCommand(
            model.poNumber,
            model.description,
            details
            );
        Result<Guid> result = await _sender.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetItemReceipt), new { id = result.Value }, result.Value);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> EditItemReceipt([FromRoute] Guid id,
        ItemReceiptRequest model,
        CancellationToken cancellationToken)
    {
        List<ItemReceiptDetailRequest> details = new List<ItemReceiptDetailRequest>();
        foreach (var item in model.itemDetails)
        {
            details.Add(new ItemReceiptDetailRequest(item.itemId,
                item.quantity,
                item.description,
                item.serialNumbers
                ));
        }
        var command = new EditItemReceiptCommand(id, model.poNumber, model.description, details);
        var result = await _sender.Send(command, cancellationToken);
        if (result == null)
            return NotFound("Item receipt not found");
        return Ok(result);
    }

    [HttpPost("{id:guid}/assets")]
    public async Task<IActionResult> ConvertToAsset([FromRoute] Guid Id, [FromBody] List<ItemReceiptAssetRequest> model)
    {
        var assetRequest = new List<AssetCreationRequest>();
        foreach (var item in model)
        {
            assetRequest.Add(new AssetCreationRequest(item.ItemReceiptDetailId, item.ItemId, item.Code, item.Name, item.AssignedTo));
        }
        var command = new ConvertToAssetCommand(Id, assetRequest);
        var result = await _sender.Send(command);
        //return CreatedAtAction(nameof(ConvertToAsset),
        //    new { id = result.Value }, result.Value);
        return Ok();
    }

    [HttpGet("{id:guid}/assets")]
    public async Task<IActionResult> GetForConvertToAsset([FromRoute] Guid Id)
    {
        var query = new GetForAssetConvertQuery(Id);
        var result = await _sender.Send(query);
        return Ok(result);
    }
}
