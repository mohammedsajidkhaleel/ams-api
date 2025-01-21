using ams.api.Extensions;
using ams.application.Employees.DeleteEmployeeAccessory;
using ams.application.Employees.GetEmployeeAccessories;
using ams.application.LicensedEmployees.CreateEmployeeAccessory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Employees;

[Authorize]
[ApiController]
[Route("api/employee")]

public class EmployeeAccessoriesController : ControllerBase
{
    ISender _sender;
    public EmployeeAccessoriesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("{employeeId}/accessories")]
    public async Task<IActionResult> CreateEmployeeAccessory([FromRoute] Guid employeeId, [FromBody] EmployeeAccessoryRequest request, CancellationToken cancellationToken = default)
    {
        var command = new CreateEmployeeAccessoryCommand(employeeId, request.AccessoryId, HttpContext.User.GetLoggedInUser());
        var assets = await _sender.Send(command, cancellationToken);
        return Ok(assets);
    }

    [HttpGet("{employeeId}/accessories")]
    public async Task<IActionResult> GetEmployeeAccessories([FromRoute] Guid employeeId, int pageIndex = 0, int pageSize = 50)
    {
        var query = new GetEmployeeAccessoriesQuery(employeeId, pageIndex, pageSize);
        return Ok(await _sender.Send(query));
    }

    [HttpDelete("accessories/{employeeAccessoryId}")]
    public async Task<IActionResult> DeleteEmployeeAccesory([FromRoute] Guid employeeAccessoryId, CancellationToken cancellationToken = default)
    {
        var command = new DeleteEmployeeAccessoryCommand(employeeAccessoryId);
        await _sender.Send(command, cancellationToken);
        return Ok();
    }
}
