using ams.application.Items.GetItemCategories;
using ams.domain.Items;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Items;

[Authorize]
[ApiController]
[Route("api/itemcategories")]
public class ItemCategoriesController : ControllerBase
{
    private ISender _iSender;
    public ItemCategoriesController(ISender iSender)
    {
        _iSender = iSender;
    }

    [HttpGet]
    public async Task<IActionResult> GetItemCategories(
        Guid? itemCategoryId,
        string searchText = "",
        CancellationToken cancellationToken = default
        )
    {
        var query = new GetItemCategoryQuery(searchText, itemCategoryId);
        var result = await _iSender.Send(query, cancellationToken);
        return Ok(result);
    }
}
