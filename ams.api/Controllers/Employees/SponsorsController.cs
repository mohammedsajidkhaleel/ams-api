using ams.application.Employees.GetSponsors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Employees
{
    [Route("api/sponsors")]
    [ApiController]
    public class SponsorsController : ControllerBase
    {
        ISender _sender;
        public SponsorsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSponsors(CancellationToken cancellationToken = default)
        {
            var query = new GetSponsorQuery();
            var sponsors = await _sender.Send(query, cancellationToken);
            return Ok(sponsors);
        }
    }
}
