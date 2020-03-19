using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace V30.Controllers {

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GoogleController : ControllerBase {
        readonly IHttpClientFactory _fact;
        readonly ILogger<GoogleController> _logger;

        public GoogleController(IHttpClientFactory fact, ILogger<GoogleController> logger) {
            _fact = fact;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Fetch2() {
            using var client = new HttpClient();
            var rs = await client.GetAsync("http://localhost:8000");
            var content = await rs.Content.ReadAsStringAsync();

            _logger.LogInformation("Length - {0}", content.Length);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Fetch() {
            var client = _fact.CreateClient();
            var rs = await client.GetAsync("http://localhost:8000");
            var content = await rs.Content.ReadAsStringAsync();

            _logger.LogInformation("Length - {0}", content.Length);
            return Ok();
        }
    }
}