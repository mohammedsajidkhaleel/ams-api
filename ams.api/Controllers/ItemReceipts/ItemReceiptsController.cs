using ams.application.ItemReceipts.CreateItemReceipt;
using ams.application.ItemReceipts.GetItemReceipt;
using ams.application.ItemReceipts.GetItemReceipts;
using ams.domain.Abstractions;
using ams.domain.ItemReceipts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace ams.api.Controllers.ItemReceipts
{
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
            List<ItemReceiptDetail> details = new List<ItemReceiptDetail>();
            foreach (var item in model.itemDetails)
            {
                details.Add(ItemReceiptDetail.Create(
                    item.itemId,
                    item.quantity,
                    ""
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
    }
}
