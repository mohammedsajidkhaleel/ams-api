﻿using ams.application.Assets.GetEmployeeAssets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Assets;

[Authorize]
[ApiController]
[Route("api/employeeassets")]

public class EmployeeAssetsController : ControllerBase
{
    ISender _sender;
    public EmployeeAssetsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{employeeId}")]
    public async Task<IActionResult> GetEmployeeAssets(Guid employeeId, CancellationToken cancellationToken = default)
    {
        var query = new GetEmployeeAssetsQuery(employeeId);
        var assets = await _sender.Send(query, cancellationToken);
        return Ok(assets);
    }
}
