using ams.application.Dashboard;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Dashboard
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class DashboardController : ControllerBase
    {
        private ISender _sender;
        public DashboardController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboardValues()
        {
            var query = new DashboardQuery();
            var result = await _sender.Send(query);
            return Ok(result);
        }

    }
}
