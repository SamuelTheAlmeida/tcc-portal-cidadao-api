using Microsoft.AspNetCore.Mvc;

namespace PortalCidadao.Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult SwaggerDoc() => Redirect("index.html");
    }
}
