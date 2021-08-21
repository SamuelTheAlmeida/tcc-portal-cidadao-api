using Microsoft.AspNetCore.Mvc;
using PortalCidadao.Application.Model;
using PortalCidadao.Application.Services.Interfaces;
using System.Threading.Tasks;

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
        public async Task<IActionResult> ListarTodos() =>
             Ok(await _service.ListarTodos());

        [HttpPost]
        public async Task<IActionResult> Inserir(PostagemModel model) =>
            Ok(await _service.Inserir(model));

        [HttpGet("categorias")]
        public async Task<IActionResult> ListarCategorias()
            => Ok(await _service.ListarCategorias());

        [HttpGet("subcategorias")]
        public IActionResult ListarSubcategorias() =>
            Ok(_service.ListarSubcategorias());


        //[HttpGet]
        //public async Task<IActionResult> ListarOrgaos()
        //{
        //    return Ok(await _service.ListarOrgaos());
        //}

    }
}
