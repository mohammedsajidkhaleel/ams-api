using ams.application.Employees.GetEmployeePositions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Employees
{
    [Route("api/employeepositions")]
    [ApiController]
    public class EmployeePositionsController : ControllerBase
    {
        ISender _sender;
        public EmployeePositionsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeePositions(CancellationToken cancellationToken = default)
        {
            var query = new GetEmployeePositionQuery();
            var positions = await _sender.Send(query, cancellationToken);
            return Ok(positions);
        }
    }
}
