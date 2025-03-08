using ams.api.Extensions;
using ams.application.PurchaseOrders.CreatePurchaseOrder;
using ams.application.PurchaseOrders.DeletePurchaseOrder;
using ams.application.PurchaseOrders.GetPoNumbers;
using ams.application.PurchaseOrders.GetPurchaseOrder;
using ams.application.PurchaseOrders.GetPurchaseOrders;
using MediatR;
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
            var query = new GetPurchaseOrdersQuery(pageIndex, pageSize, poNumber);
            var purchaseOrders = await sender.Send(query, cancellationToken);
            return Ok(purchaseOrders);
        }

        [HttpGet, Route("{id:guid}")]
        public async Task<IActionResult> GetPurchaseOrder(
            Guid id,
            CancellationToken cancellationToken)
        {
            var query = new GetPurchaseOrderQuery(id);
            var purchaseOrder = await sender.Send(query, cancellationToken);
            return Ok(purchaseOrder);
        }

        [HttpGet, Route("numbers")]
        public async Task<IActionResult> GetAllPurchaseOrderNumbers(
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
                model.Description,
                model.Items.Select(i => new CreatePurchaseOrderItemCommand(i.ItemId, i.Quantity)).ToList());
            var result = await sender.Send(
                command,
                cancellationToken);
            return CreatedAtAction(nameof(CreatePurchaseOrder),
                new { id = result.Value }, result.Value);
        }

        [HttpDelete, Route("{id:guid}")]
        public async Task<IActionResult> DeletePurchaseOrder(
            Guid id,
            CancellationToken cancellationToken)
        {
            var command = new DeletePurchaseOrderCommand(id);
            var result = await sender.Send(command, cancellationToken);
            return 
        }
    }

}
