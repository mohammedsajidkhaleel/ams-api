using ams.application.Items.GetItem;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Items;

[Authorize]
[ApiController]
[Route("api/items")]
public class ItemsController : ControllerBase
{
    private ISender _sender;
    public ItemsController(ISender sender)
    {
        _sender = sender;
    }
    [HttpGet]
    public async Task<IActionResult> GetItems(
        Guid? itemCategoryId
        , string searchText = ""
        , CancellationToken cancellationToken = default)
    {
        var itemQuery = new GetItemQuery(searchText, itemCategoryId);
        var result = await _sender.Send(itemQuery, cancellationToken);
        return Ok(result.Value);
    }
}
