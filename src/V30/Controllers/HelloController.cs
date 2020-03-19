using Microsoft.AspNetCore.Mvc;

namespace V30.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HelloController : ControllerBase {

        [HttpGet]
        public ActionResult<string> Go() => "Hello";
    }
}