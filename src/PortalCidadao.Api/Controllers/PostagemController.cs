using Microsoft.AspNetCore.Mvc;
using PortalCidadao.Application.Services.Interfaces;

namespace PortalCidadao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostagemController : ControllerBase
    {
        private readonly IPostagemService _service;
        public PostagemController(IPostagemService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.ListarTodos());
        }
    }
}
