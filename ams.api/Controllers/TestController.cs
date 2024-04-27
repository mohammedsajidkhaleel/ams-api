using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ams.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        IConfiguration _configuration;
        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            return Ok($"all fine. {_configuration.GetConnectionString("Database")} {_configuration.GetValue<string
                >("ApplicationSettings:AllowedCorsOrigins")}");
        }
    }
}
