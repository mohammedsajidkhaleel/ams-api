using ams.api.Extensions;
using ams.application.Assets.GetAssets;
using ams.application.Assets.GetPoNumbers;
using ams.application.PurchaseOrders.CreatePurchaseOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.PurchaseOrders
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrdersController(ISender sender)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllPurchaseOrders(
       int pageIndex = 0,
       int pageSize = 10,
       string poNumber = "",
       CancellationToken cancellationToken = default)
        {
            var query = new GetPoNumbersQuery(pageIndex, pageSize, poNumber);
            var purchaseOrders = await sender.Send(query, cancellationToken);
            return Ok(purchaseOrders);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePurchaseOrder(
            PurchaseOrderRequest model,
            CancellationToken cancellationToken)
        {
            var command = new CreatePurchaseOrderCommand(
                model.PoNumber,
                model.PurchaseDate,
                HttpContext.User.GetLoggedInUser(),
                "",
                model.Items.Select(i => new CreatePurchaseOrderItemCommand(i.ItemId, i.Quantity)).ToList());
            var result = await sender.Send(
                command,
                cancellationToken);
            return CreatedAtAction(nameof(CreatePurchaseOrder),
                new { id = result.Value }, result.Value);
        }
    }

}
