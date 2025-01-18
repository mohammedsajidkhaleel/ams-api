using ams.application.Employees.GetDepartments;
using ams.domain.Employees;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Employees
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        ISender _sender;
        public DepartmentsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments(CancellationToken cancellationToken = default
            )
        {
            var query = new GetDepartmentQuery(null, null);
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{departmentId:guid}/childs")]
        public async Task<IActionResult> GetDepartmentsByParentId(
           Guid? departmentId, CancellationToken cancellationToken = default
           )
        {
            var query = new GetDepartmentQuery(null, departmentId);
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
