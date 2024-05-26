using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Reports
{
    [Authorize]
    [ApiController] 
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
    }
}
