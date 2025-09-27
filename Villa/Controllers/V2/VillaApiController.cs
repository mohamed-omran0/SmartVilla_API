using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Villa.Controllers.V2
{
    [Route("api/v{version:apiVersion}/VillaApi")]
    [ApiController]
    [ApiVersion("2.0")]
    public class VillaApiController : ControllerBase
    {
      
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("V2 (:");
        }
    }
}
