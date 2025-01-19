using ams.api.Extensions;
using ams.application.Sims.CreateSim;
using ams.application.Sims.GetSims;
using ams.domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Sims;

[Authorize]
[ApiController]
[Route("api/[controller]")]

public class SimsController : ControllerBase
{
    ISender _sender;
    public SimsController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost]
    public async Task<IActionResult> CreateSim(SimRequest model,
               CancellationToken cancellationToken)
    {
        var command = new CreateSimCommand(
       model.ServiceAccount,
       model.ServiceNumber,
       model.SimCardNumber,
       model.Imei1,
       HttpContext.User.GetLoggedInUser(),
       model.AssignedTo
            );
        Result<Guid> result = await _sender.Send(command, cancellationToken);
        return CreatedAtAction(nameof(CreateSim),
            new { id = result.Value }, result.Value);
    }

    //[HttpPut("{id:Guid}")]
    //public async Task<IActionResult> EditSim([FromRoute] Guid id,
    //    SimRequest model,
    //    CancellationToken cancellationToken)
    //{
    //    var command = new EditSimCommand(
    //        id,
    //        model.Code,
    //     model.Name,
    //     model.SerialNumber,
    //     model?.AssignedTo,
    //     model?.ProjectId,
    //     model?.Description ?? "",
    //     model?.ItemId,
    //     model?.PONumber ?? "");
    //    Result<Guid> result = await _sender.Send(command, cancellationToken);
    //    return Ok(new { id = result.Value });


    //[HttpDelete("{id:Guid}")]
    //public async Task<IActionResult> DeleteSim([FromRoute] Guid id,
    //    CancellationToken cancellationToken)
    //{
    //    var command = new DeleteSimCommand(id);
    //    await _sender.Send(command, cancellationToken);
    //    return Ok();
    //}

    [HttpGet]
    public async Task<IActionResult> GetAllSims(
        int pageIndex = 0,
        int pageSize = 10,
        string searchQuery = "",
        CancellationToken cancellationToken = default)
    {
        var query = new GetSimsQuery(searchQuery, pageIndex, pageSize);
        var assets = await _sender.Send(query, cancellationToken);
        return Ok(assets);
    }

}
